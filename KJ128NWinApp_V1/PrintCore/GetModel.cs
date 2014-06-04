using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using System.Data;
using KJ128NInterfaceShow;


namespace PrintCore
{
    /// <summary>
    /// 打印导出模板
    /// 钱耀祖   201-3-22
    /// 负责为打印，导出，设置提供数据模板
    /// </summary>
    public class GetModel
    {
        public static void GetDataTable(PrintModel model, DataGridView dgv)
        {
            List<string> strColumns = new List<string>();
            List<string> strHeaderText = new List<string>();
            DataTable DtTemp = null;
            try
            {
               
                DtTemp = (dgv.DataSource as DataTable).Copy();
                //删除隐藏的datatcolumn列
                foreach (DataGridViewColumn col in dgv.Columns)
                {
                    if (col.Visible == false)//|| col.GetType().ToString() == "System.Windows.Forms.DataGridViewCheckBoxColumn"
                    {
                        if (DtTemp.Columns.Contains(col.Name))
                            DtTemp.Columns.Remove(col.Name);
                    }
                }

                for (int i = 0; i < dgv.Columns.Count; i++)
                {
                    strColumns.Add("");
                    strHeaderText.Add("");
                }

                for (int i = 0; i < dgv.Columns.Count; i++)
                {
                    if (dgv.Columns[i].Visible == true)
                    {
                        strColumns[dgv.Columns[i].DisplayIndex] = dgv.Columns[i].Name.ToString();
                        strHeaderText[dgv.Columns[i].DisplayIndex] = dgv.Columns[i].HeaderText.ToString();
                    }
                }
                while (strColumns.Contains(""))
                {
                    strColumns.Remove("");
                    strHeaderText.Remove("");
                }
                
                //根据保存的模板设置列顺序
                if (model.Columns.Count != 0 && DtTemp.TableName != "Table" && DtTemp.TableName != "A_InitialData")
                {
                    //设置datatable列索引
                    //string[] tempStr = model.Columns.Split(',');
                    for (int i = 0; i < model.Columns.Count; i++)
                    {
                        DtTemp.Columns[model.Columns[i].ToString()].SetOrdinal(i);
                    }
                }
                else
                {
                    //根据displayindex设置列顺序
                    for (int i = 0; i < strColumns.Count; i++)
                    {
                        DtTemp.Columns[strColumns[i]].SetOrdinal(i);
                    }
                }
                if (strColumns.Count != 0 && strColumns.Count != 0)
                {
                    model.Columnname = strColumns;
                    model.Columntext = strHeaderText;
                }
            }
            catch(Exception ee)
            {
                if (DtTemp == null)
                {
                    if (!ee.Message.Equals("正在中止线程。"))
                    {
                        MessageBox.Show("由于系统错误导出任务未执行", "提示");
                    }
                    return;
                }
            }
            model.Printtable = DtTemp;
        }

        /// <summary>
        /// 获取Model
        /// </summary>
        /// <param name="Grid"></param>
        /// <param name="PrintName"></param>
        /// <param name="TjTime"></param>
        /// <returns></returns>
        public static PrintModel getMode(DataGridView Grid, string PrintName, string TjTime)
        {
            PrintModel model = new PrintModel();

            #region[加载打印基础配置信息]
            //if (TjTime.ToString().Contains("统计时间"))
            //{
            //    model.Tjtime = Grid.;
            //}
            //else
            //{
            //    model.Tjtime = "";
            //}
            model.Tjtime = "共 "+Grid.Rows.Count+" 条记录";
            string tableName = string.Empty;
         
            tableName = (Grid.DataSource as DataTable).TableName.ToString();
            if (!Directory.Exists(Application.StartupPath.ToString() + "\\PrintSetModel"))
            {
                Directory.CreateDirectory(Application.StartupPath.ToString() + "\\PrintSetModel");
            }
            if (!File.Exists(Application.StartupPath.ToString() + "\\PrintSetModel\\" + tableName + ".xml"))
            {
                FileStream fs = new FileStream(Application.StartupPath.ToString() + "\\PrintSetModel\\" + tableName + ".xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                StreamWriter ws = new StreamWriter(fs);
                ws.WriteLine("<PrintSet>");
                ws.WriteLine("<TableName></TableName>");
                ws.WriteLine("<Font>");
                ws.WriteLine("<TitleFont>宋体,21.75,Center</TitleFont>");
                ws.WriteLine("<subTitleFont>宋体,7.5,Center</subTitleFont>");
                ws.WriteLine("<ContentFont>宋体,7.5,Center</ContentFont>");
                ws.WriteLine("<SignFont>宋体,10.5,Center</SignFont>");
                ws.WriteLine("</Font>");
                ws.WriteLine("<PageSet>");
                ws.WriteLine("<PageSize>21,29.7</PageSize>");//cm
                ws.WriteLine("<Margin>0.5,0.5,0.5,0.5</Margin>");//cm
                ws.WriteLine("</PageSet>");
                ws.WriteLine("<Sign>");
                ws.WriteLine("<LeaderList>制表人,,,</LeaderList>");
                ws.WriteLine("</Sign>");
                ws.WriteLine("<Content>");
                ws.WriteLine("<Columns></Columns>");
                ws.WriteLine("<Width></Width>");
                ws.WriteLine("</Content>");
                ws.WriteLine("</PrintSet>");
                ws.Close();
                ws.Dispose();
                fs.Close();
                fs.Dispose();
            }
            XmlDocument doc = new XmlDocument();
            doc.Load(Application.StartupPath.ToString() + "\\PrintSetModel\\" + tableName + ".xml");
            //表格名称
            
            model.Printname = doc.SelectSingleNode("/PrintSet/TableName").InnerText.ToString();
            if (model.Printname == "")
                model.Printname = PrintName;
            //标题栏字体
            string[] Temp = doc.SelectSingleNode("/PrintSet/Font/TitleFont").InnerText.ToString().Trim().Split(',');
            model.Titlefontfamily = Temp[0].ToString();
            model.Titlefontsize = (float)(Convert.ToDouble(Temp[1].ToString()));
            model.Titlefontstyle = Temp[2].ToString();

            //副标题字体
            Temp = doc.SelectSingleNode("/PrintSet/Font/subTitleFont").InnerText.ToString().Trim().Split(',');
            model.Subfontfamily = Temp[0].ToString();
            model.Subfontsize = (float)(Convert.ToDouble(Temp[1].ToString()));
            model.Subfontstyle = Temp[2].ToString();

            //表格字体
            Temp = doc.SelectSingleNode("/PrintSet/Font/ContentFont").InnerText.ToString().Trim().Split(',');
            model.Contentfontfamily = Temp[0].ToString();
            model.Contentfontsize = (float)(Convert.ToDouble(Temp[1].ToString()));
            model.Contentfontstyle = Temp[2].ToString();

            //签名栏字体
            Temp = doc.SelectSingleNode("/PrintSet/Font/SignFont").InnerText.ToString().Trim().Split(',');
            model.Signfontfamily = Temp[0].ToString();
            model.Signfontsize = (float)(Convert.ToDouble(Temp[1].ToString()));
            model.Signfontstyle = Temp[2].ToString();

            //纸张大小
            Temp = doc.SelectSingleNode("/PrintSet/PageSet/PageSize").InnerText.ToString().Trim().Split(',');
            model.Paperwidth = Temp[0].ToString();
            model.Paperheight = Temp[1].ToString();

            //纸张边距
            Temp = doc.SelectSingleNode("/PrintSet/PageSet/Margin").InnerText.ToString().Trim().Split(',');
            model.Papertop = Temp[0].ToString();
            model.Paperbottom = Temp[1].ToString();
            model.Paperleft = Temp[2].ToString();
            model.Paperright = Temp[3].ToString();

            //签名栏内容
            model.Signcontent = doc.SelectSingleNode("/PrintSet/Sign/LeaderList").InnerText.ToString().Trim();

            //表格选择的列名集合
            string temp = doc.SelectSingleNode("/PrintSet/Content/Columns").InnerText.ToString().Trim();
            if (temp != "")
            {
                foreach (string strTemp in temp.Split(','))
                {
                    model.Columns.Add(strTemp);
                }
            }

            //表格选择的列宽集合
            temp = doc.SelectSingleNode("/PrintSet/Content/Width").InnerText.ToString().Trim();
            if (temp != "")
            {
                foreach (string strTemp in temp.Split(','))
                {
                    model.Columnswidth.Add(strTemp);
                }
            }
            #endregion

            //加工成有效的数据源
            GetDataTable(model, Grid);

            return model;
        }
      
        
    }
}
