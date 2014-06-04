using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Xml;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using Microsoft.Reporting.WinForms;
using KJ128NInterfaceShow;
using System.Threading;
using System.Drawing.Printing;
using System.Drawing.Imaging;
using System.Security.AccessControl;

namespace PrintCore
{
    public partial class FormPrint : Form , IPrintComponent
    {
        #region [ 字段 属性 构造函数 ]

        private bool isLoaded = false;
        PrintModel Model = null;
        private bool autoPrint = false;

        /// <summary>
        /// 字段与列的映射
        /// </summary>
        Collection<FieldMappingColumn> mapping = null;

        /// <summary>
        /// 模板文件路径
        /// </summary>
        private string templateFilePath = Application.StartupPath + @"\Template\Template.rdlc";

        /// <summary>
        /// 读取保存模板文件
        /// </summary>
        private XmlDocument doc = new XmlDocument();

        /// <summary>
        /// 是否加载过模板
        /// </summary>
        private bool isTemplateFileLoaded = false;

        /// <summary>
        /// 是否加载过模板
        /// </summary>
        private bool IsTemplateFileLoaded
        {
            get
            {
                return isTemplateFileLoaded;
            }
        }

        public FormPrint(PrintModel model)
        {
            InitializeComponent();
            Model = model;
        }
        public FormPrint()
        {
            InitializeComponent();
        }


        #endregion

        #region [ 私有方法 ]

        /// <summary>
        /// 加载模板文件
        /// </summary>
        /// <param name="path">模板文件路径</param>
        private void LoadTemplateFile(string path)
        {
            templateFilePath = path;
            LoadTemplateFile();
        }
        
        /// <summary>
        /// 加载模板文件
        /// </summary>
        private void LoadTemplateFile()
        {
            if (templateFilePath != "" && templateFilePath != String.Empty)
            {
                if (File.Exists(templateFilePath))
                {
                    if (doc == null)
                        doc = new XmlDocument();
                    try
                    {
                        XmlDocument xml = new XmlDocument();
                        xml.Load(templateFilePath);
                        XmlNodeList nodes = xml.ChildNodes[1].ChildNodes;
                        foreach (XmlNode n in nodes)
                        {
                            switch (n.LocalName)
                            {
                                case "InteractiveHeight": n.InnerText = Model.Paperheight.ToString() + "cm"; break;
                                case "InteractiveWidth": n.InnerText = Convert.ToDouble(Model.Paperwidth).ToString() + "cm"; break; //(Convert.ToDouble(Model.Paperwidth) - Convert.ToDouble(Model.Paperleft)-Convert.ToDouble(Model.Paperright)).ToString() + "cm"; break;
                                case "RightMargin": n.InnerText = Model.Paperright.ToString() + "cm"; break;
                                case "LeftMargin": n.InnerText = Model.Paperleft.ToString() + "cm"; break;
                                case "BottomMargin": n.InnerText = Model.Paperbottom.ToString() + "cm"; break;
                                case "TopMargin": n.InnerText = Model.Papertop.ToString() + "cm"; break;
                                case "PageWidth": n.InnerText = (Convert.ToDouble(Model.Paperwidth) + 0.2).ToString() + "cm"; break;
                                case "PageHeight": n.InnerText = Model.Paperheight.ToString() + "cm"; break;
                                case "Width": n.InnerText = (Convert.ToDouble(Model.Paperwidth) - Convert.ToDouble(Model.Paperleft) - Convert.ToDouble(Model.Paperright)).ToString() + "cm"; break;
                                default: break;
                            }
                        }

                        //xml.ChildNodes[1].SelectSingleNode("/InteractiveHeight").InnerText = Model.Paperheight.ToString() + "cm";
                        //xml.SelectSingleNode("/Report/InteractiveWidth").InnerText = Model.Paperwidth.ToString() + "cm";
                        //xml.SelectSingleNode("/Report/RightMargin").InnerText = Model.Paperright.ToString() + "cm";
                        //xml.SelectSingleNode("/Report/LeftMargin").InnerText = Model.Paperleft.ToString() + "cm";
                        //xml.SelectSingleNode("/Report/BottomMargin").InnerText = Model.Paperbottom.ToString() + "cm";
                        //xml.SelectSingleNode("/Report/TopMargin").InnerText = Model.Papertop.ToString() + "cm";
                        //xml.SelectSingleNode("/Report/PageWidth").InnerText = Model.Paperwidth.ToString() + "cm";
                        //xml.SelectSingleNode("/Report/PageHeight").InnerText = Model.Paperheight.ToString() + "cm";
                        //xml.SelectSingleNode("/Report/Width").InnerText = Model.Paperwidth.ToString() + "cm";
                        xml.Save(templateFilePath);
                        //if (!isTemplateFileLoaded)
                        //{
                        doc.Load(templateFilePath);
                        //isTemplateFileLoaded = true;
                        //}
                    }
                    catch
                    {
                        MessageBox.Show("加载模板文件[" + templateFilePath + "]失败,请确保其是否正在使用或损坏", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("请检查模板文件[" + templateFilePath + "]是否存在", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("模板文件[" + templateFilePath + "]未指定", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        /// <summary>
        /// 调出打印窗体
        /// </summary>
        /// <param name="dt">DataTable数据源</param>
        /// <param name="mappings">字段对应报表列的映射</param>
        /// <param name="printParams">其他参数 至少三个 
        /// 第一是Dataset名，可随便填
        /// 第二是打印标题
        /// 第三是打印日期
        /// </param>
        private void CallPrintForm(DataTable dt, Collection<FieldMappingColumn> mappings,params object[] printParams)
        {
            try
            {
                DelFile();
                LoadTemplateFile();

                doc = Initialize(dt, mappings, printParams);

                //if(!Directory.Exists(Application.StartupPath + @"\PrintFile"))
                //{
                //    Directory.CreateDirectory(Application.StartupPath + @"\PrintFile");
                //}

                //保存文件
                string filePath = Application.StartupPath + @"\PrintFile\" + DateTime.Now.ToString("yyyyMMddhhmmss") + "print.rdlc";

                if (!File.Exists(filePath))
                {
                    int po = filePath.LastIndexOf(Convert.ToChar(@"\"));
                    string dir = filePath.Substring(0, po);
                    Directory.CreateDirectory(dir);
                }

                doc.Save(filePath);

                //给报表文件赋相应的属性
                this.PrintView.LocalReport.ReportPath = filePath;

                //this.PrintView.LocalReport.ReportPath = @"C:\Documents and Settings\Administrator\桌面\打印方案\reportViewer\PrintTest\PrintTest\bin\Debug\PrintFile\20080407082030print.rdlc";

                ReportDataSource source = new ReportDataSource(printParams[0].ToString(), dt);
                
                this.PrintView.LocalReport.DataSources.Clear();
                this.PrintView.LocalReport.DataSources.Add(source);
                if (autoPrint)
                {
                    //Thread t = new Thread(new ThreadStart(this.PrintReport));
                    //t.Start();
                    PrintReport();
                }
                else
                {
                    this.WindowState = FormWindowState.Maximized;
                    this.ShowDialog();
                }


                //PrintReport(this.PrintView.LocalReport);
                //this.Dispose();
                //this.autoPrint = isAutoPrint;
                

                try
                {

                    if (File.Exists(filePath))
                    {
                        //删除文件
                        File.Delete(filePath);
                    }
                }
                catch (IOException ioe)
                {
                    MessageBox.Show("删除报表文件失败，错误信息["+ioe.Message+"]","提示",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception e)
            {

                MessageBox.Show("生成报表文件，显示数据时出错，错误信息：" + e.Message ,"提示",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
        }

        #region[直接打印]
        private List<Stream> m_streams = new List<Stream>();
        private int m_currentPageIndex;

        private void PrintReport()
        {
            string deviceInfo =
          "<DeviceInfo>" +
          "  <OutputFormat>EMF</OutputFormat>" +
          "  <PageWidth>8.5in</PageWidth>" +
          "  <PageHeight>11in</PageHeight>" +
          "  <MarginTop>0.25in</MarginTop>" +
          "  <MarginLeft>0.25in</MarginLeft>" +
          "  <MarginRight>0.25in</MarginRight>" +
          "  <MarginBottom>0.25in</MarginBottom>" +
          "</DeviceInfo>";
            Warning[] warnings;
            m_streams = new List<Stream>();
            LocalReport report = this.PrintView.LocalReport;
            report.Render("Image", deviceInfo, CreateStream, out warnings);
            foreach (Stream stream in m_streams)
                stream.Position = 0;

            const string printerName = "Microsoft Office Document Image Writer";

            if (m_streams == null || m_streams.Count == 0)
                return;

            PrintDocument printDoc = new PrintDocument();
            printDoc.EndPrint += new PrintEventHandler(printDoc_EndPrint);
            //printDoc.PrinterSettings.PrinterName = printerName;
            //if (printDoc.PrinterSettings.PrinterName == printerName)
            //{
            //    MessageBox.Show("无法找到打印机,请设置好默认打印机...", "错误");
            //}
            if (!printDoc.PrinterSettings.IsValid)
            {
                string msg = "无法找到打印机,请设置好默认打印机...";
                MessageBox.Show(msg, "错误");
                return;
            }
            printDoc.PrintPage += new PrintPageEventHandler(PrintPage);
            printDoc.Print();
            //Thread.CurrentThread.Abort();
        }

        void printDoc_EndPrint(object sender, PrintEventArgs e)
        {
            //string[] filename = Directory.GetFiles(Application.StartupPath + @"\PrintFile");
            //foreach (string fname in filename)
            //{
            //     File.Delete(fname);
            //}
        }

        private void DelFile()
        {
            if (!Directory.Exists(Application.StartupPath + @"\PrintFile"))
            {
                Directory.CreateDirectory(Application.StartupPath + @"\PrintFile");
            }

            string[] filename = Directory.GetFiles(Application.StartupPath + @"\PrintFile");
            foreach (string fname in filename)
            {
                if (File.GetCreationTime(fname) < DateTime.Parse(DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd 00:00:00")))
                {
                    try
                    {
                        File.Delete(fname);
                    }
                    catch (Exception ex)
                    {
                        continue;
                    }
                }
            }
        }

        private void PrintPage(object sender, PrintPageEventArgs ev)
        {
            Metafile pageImage = new Metafile(m_streams[m_currentPageIndex]);
            m_streams[m_currentPageIndex].Close();
            m_streams[m_currentPageIndex].Dispose();
            ev.Graphics.DrawImage(pageImage, ev.PageBounds);

            m_currentPageIndex++;
            if (!(m_currentPageIndex < m_streams.Count))
            {
                StreamDispose();
            }
            ev.HasMorePages = (m_currentPageIndex < m_streams.Count);
        }

        private Stream CreateStream(string name, string fileNameExtension, Encoding encoding, string mimeType, bool willSeek)
        {
            Stream stream = new FileStream(Application.StartupPath + @"\PrintFile\" + name +
              "." + fileNameExtension, FileMode.Create);
            m_streams.Add(stream);
            return stream;
        }

        private void StreamDispose()
        {
            if (m_streams != null)
            {
                foreach (Stream stream in m_streams)
                    stream.Close();
                //m_streans = null;
            }
        }

        #endregion

        /// <summary>
        /// 初始化报表文件格式
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private XmlDocument Initialize(DataTable dt, Collection<FieldMappingColumn> mappings, params object[] printParams)
        {
            try
            {
                //ds名
                string dsName = printParams[0].ToString();

                if (dt.TableName == "" || dt.TableName == String.Empty)
                {
                    dt.TableName = "MyTable";
                }

                //dt名
                string tableName = dt.TableName;


                
                XmlNode root = doc.ChildNodes[1];

                if (root != null)
                {
                    
                    #region [DataSources]

                    /*
                 
                 </DataSources>
                    <DataSource Name="DummyDataSource">
                      <rd:DataSourceID>ce708b6d-d21c-4c76-aa8a-e022bde9756f</rd:DataSourceID>
                      <ConnectionProperties>
                        <DataProvider>SQL</DataProvider>
                        <ConnectString />
                      </ConnectionProperties>
                    </DataSource>
                  </DataSources>
                                 
                 
                 */
                    //DataSources
                    XmlNode dataSources = doc.CreateElement("DataSources", root.NamespaceURI);

                    //DataSource
                    XmlNode dataSource = doc.CreateElement("DataSource", root.NamespaceURI);
                    XmlAttribute dataSourceatt = doc.CreateAttribute("Name");
                    dataSourceatt.Value = "DummyDataSource";
                    dataSource.Attributes.Append(dataSourceatt);

                    //DataSourceID
                    XmlNode dataSourceID = doc.CreateElement("rd", "DataSourceID", root.Attributes[1].Value);
                    dataSourceID.InnerText = "ce708b6d-d21c-4c76-aa8a-e022bde9756f";

                    //ConnectionProperties
                    XmlNode onnectionProperties = doc.CreateElement("ConnectionProperties", root.NamespaceURI);

                    //DataProvider
                    XmlNode dataProvider = doc.CreateElement("DataProvider", root.NamespaceURI);
                    dataProvider.InnerText = "SQL";

                    //ConnectString
                    XmlNode connectString = doc.CreateElement("ConnectString", root.NamespaceURI);

                    onnectionProperties.AppendChild(dataProvider);
                    onnectionProperties.AppendChild(connectString);

                    dataSource.AppendChild(dataSourceID);
                    dataSource.AppendChild(onnectionProperties);

                    dataSources.AppendChild(dataSource);

                    #endregion

                    # region [DataSets]
                    //DataSets
                    XmlNode dses = doc.CreateElement("DataSets", root.NamespaceURI);
                    //dses.InnerText = "DataSets";

                    //DataSet
                    XmlNode ds = doc.CreateElement("DataSet", root.NamespaceURI);

                    XmlAttribute att = doc.CreateAttribute("Name");
                    att.Value = dsName;
                    ds.Attributes.Append(att);



                    #region [Fields]
                    //Fields
                    XmlNode fields = doc.CreateElement("Fields", root.NamespaceURI);

                    for (int i = 0; i < mappings.Count; i++)
                    {
                        //Field
                        XmlNode field = doc.CreateElement("Field", root.NamespaceURI);

                        XmlAttribute attField = doc.CreateAttribute("Name");
                        attField.Value = mappings[i].Filed.ToString();
                        field.Attributes.Append(attField);

                        XmlNode dataField = doc.CreateElement("DataField", root.NamespaceURI);
                        dataField.InnerText = mappings[i].Filed.ToString();

                        XmlNode typeName = doc.CreateElement("rd", "TypeName", root.Attributes[1].Value);
                        typeName.InnerText = "System.String";

                        field.AppendChild(dataField);
                        field.AppendChild(typeName);
                        fields.AppendChild(field);
                    }

                    ds.AppendChild(fields);

                    #endregion

                    #region [Query]
                    XmlNode query = doc.CreateElement("Query", root.NamespaceURI);
                    //<DataSourceName>DummyDataSource</DataSourceName>
                    //<CommandText />
                    //<rd:UseGenericDesigner>true</rd:UseGenericDesigner>

                    XmlNode dataSourceName = doc.CreateElement("DataSourceName", root.NamespaceURI);
                    dataSourceName.InnerText = "DummyDataSource";
                    XmlNode commandText = doc.CreateElement("CommandText", root.NamespaceURI);
                    XmlNode useGenericDesigner = doc.CreateElement("rd", "UseGenericDesigner", root.Attributes[1].Value);
                    useGenericDesigner.InnerText = "true";
                    query.AppendChild(dataSourceName);
                    query.AppendChild(commandText);
                    query.AppendChild(useGenericDesigner);
                    #endregion

                    #region [rd:DataSetInfo]

                    /*
                 * <rd:DataSetInfo>
                    <rd:DataSetName>Myds</rd:DataSetName>
                    <rd:TableName>Table</rd:TableName>
                  </rd:DataSetInfo>
                 */
                    //DataSetInfo
                    XmlNode dataSetInfo = doc.CreateElement("rd", "DataSetInfo", root.Attributes[1].Value);
                    //DataSetName
                    XmlNode dataSetName = doc.CreateElement("rd", "DataSetName", root.Attributes[1].Value);
                    dataSetName.InnerText = dsName;
                    //TableName
                    XmlNode tableNameX = doc.CreateElement("rd", "TableName", root.Attributes[1].Value);
                    tableNameX.InnerText = tableName;
                    dataSetInfo.AppendChild(dataSetName);
                    dataSetInfo.AppendChild(tableNameX);

                    #endregion


                    ds.AppendChild(query);
                    ds.AppendChild(dataSetInfo);
                    dses.AppendChild(ds);


                    # endregion [DataSets]

                    #region [Body]

                    XmlNode body = root.ChildNodes[11];

                    if (body != null)
                    {
                        //string name =  body.LocalName;

                        #region [ReportItems]
                        //ReportItems
                        XmlNode reportItems = doc.CreateElement("ReportItems", root.NamespaceURI);
                        #region [Table]
                        //Table
                        XmlNode table = doc.CreateElement("Table", root.NamespaceURI);

                        XmlAttribute tableatt = doc.CreateAttribute("Name");
                        tableatt.Value = tableName;
                        table.Attributes.Append(tableatt);

                        #region [DataSetName]
                        XmlNode dataSetNameX = doc.CreateElement("DataSetName", root.NamespaceURI);
                        dataSetNameX.InnerText = dsName;
                        #endregion

                        #region [Top]

                        XmlNode top = doc.CreateElement("Top", root.NamespaceURI);
                        top.InnerText = "0cm";
                        table.AppendChild(top);

                        #endregion

                        #region [Left]

                        XmlNode left = doc.CreateElement("Left", root.NamespaceURI);
                        left.InnerText = "0cm";
                        table.AppendChild(left);

                        #endregion

                        #region [Height]

                        XmlNode height = doc.CreateElement("Height", root.NamespaceURI);
                        height.InnerText = "2cm";
                        table.AppendChild(height);
                        #endregion

                        #region [内容]
                        XmlNode details = doc.CreateElement("Details", root.NamespaceURI);

                        XmlNode dtableRows = doc.CreateElement("TableRows", root.NamespaceURI);
                        XmlNode dtableRow = doc.CreateElement("TableRow", root.NamespaceURI);
                        //<Height>0.63492cm</Height>
                        XmlNode dheight = doc.CreateElement("Height", root.NamespaceURI);
                        dheight.InnerText =  "0.63492cm";                  

                        XmlNode dtableCells = doc.CreateElement("TableCells", root.NamespaceURI);

                        //这里开始
                        for (int i = 0; i < mappings.Count; i++)
                        {
                            XmlNode dtableCell = doc.CreateElement("TableCell", root.NamespaceURI);

                            XmlNode dtextbox = doc.CreateElement("Textbox", root.NamespaceURI);

                            XmlAttribute dtextboxatt = doc.CreateAttribute("Name");
                            dtextboxatt.Value = mappings[i].Filed.ToString();
                            dtextbox.Attributes.Append(dtextboxatt);

                            XmlNode ddefaultName = doc.CreateElement("rd", "DefaultName", root.Attributes[1].Value);
                            ddefaultName.InnerText = mappings[i].Filed.ToString();
                            dtextbox.AppendChild(ddefaultName);


                            XmlNode dzIndex = doc.CreateElement("ZIndex", root.NamespaceURI);
                            dzIndex.InnerText = Convert.ToString(((i + 1)));
                            dtextbox.AppendChild(dzIndex);

                            XmlNode dcanGrow = doc.CreateElement("CanGrow", root.NamespaceURI);
                            dcanGrow.InnerText = "true";
                            dtextbox.AppendChild(dcanGrow);

                            XmlNode dvalue = doc.CreateElement("Value", root.NamespaceURI);
                            dvalue.InnerText = "=Fields!" + mappings[i].Filed.ToString() + ".Value";
                            dtextbox.AppendChild(dvalue);

                            XmlNode dstyle = doc.CreateElement("Style", root.NamespaceURI);

                            XmlNode dBorderStyle = doc.CreateElement("BorderStyle", root.NamespaceURI);

                            XmlNode dDefault = doc.CreateElement("Default", root.NamespaceURI);
                            dDefault.InnerText = "Solid";
                            dBorderStyle.AppendChild(dDefault);

                            dstyle.AppendChild(dBorderStyle);

                            /*
                             * <TextAlign>Center</TextAlign>
                             */

                            XmlNode dTextAlign = doc.CreateElement("TextAlign", root.NamespaceURI);
                            //dTextAlign.InnerText = "Center";
                            dTextAlign.InnerText = Model.Contentfontstyle.ToString();
                            dstyle.AppendChild(dTextAlign);

                            XmlNode dfontFamily = doc.CreateElement("FontFamily", root.NamespaceURI);
                            //dfontFamily.InnerText = "宋体";
                            dfontFamily.InnerText = Model.Contentfontfamily.ToString();
                            dstyle.AppendChild(dfontFamily);

                            XmlNode dFontSize = doc.CreateElement("FontSize", root.NamespaceURI);
                            dFontSize.InnerText = (Model.Contentfontsize / 72 * 96).ToString("0.0") + "pt";// "22pt";
                            dstyle.AppendChild(dFontSize);

                            XmlNode dpaddingLeft = doc.CreateElement("PaddingLeft", root.NamespaceURI);
                            dpaddingLeft.InnerText = "2pt";
                            dstyle.AppendChild(dpaddingLeft);

                            XmlNode dpaddingRight = doc.CreateElement("PaddingRight", root.NamespaceURI);
                            dpaddingRight.InnerText = "2pt";
                            dstyle.AppendChild(dpaddingRight);

                            XmlNode dpaddingTop = doc.CreateElement("PaddingTop", root.NamespaceURI);
                            dpaddingTop.InnerText = "2pt";
                            dstyle.AppendChild(dpaddingTop);

                            XmlNode dpaddingBottom = doc.CreateElement("PaddingBottom", root.NamespaceURI);
                            dpaddingBottom.InnerText = "2pt";
                            dstyle.AppendChild(dpaddingBottom);

                            dtextbox.AppendChild(dstyle);


                            //dtableCell.AppendChild(dtextbox);

                            XmlNode dreportItems = doc.CreateElement("ReportItems", root.NamespaceURI);
                            dreportItems.AppendChild(dtextbox);
                            dtableCell.AppendChild(dreportItems);

                            dtableCells.AppendChild(dtableCell);
                        }


                        dtableRow.AppendChild(dheight);
                        dtableRow.AppendChild(dtableCells);
                        dtableRows.AppendChild(dtableRow);
                        details.AppendChild(dtableRows);
                        table.AppendChild(details);
                        #endregion

                       

                        #region [TableColumns]
                        XmlNode tableColumns = doc.CreateElement("TableColumns", root.NamespaceURI);

                        /*<TableColumn>
                            <Width>5.33333cm</Width>
                        </TableColumn>*/

                        for (int i = 0; i < mappings.Count; i++)
                        {
                            XmlNode tableColumn = doc.CreateElement("TableColumn", root.NamespaceURI);

                            XmlNode width = doc.CreateElement("Width", root.NamespaceURI);
                            width.InnerText = mappings[i].ColumnWidth + "cm";

                            tableColumn.AppendChild(width);
                            tableColumns.AppendChild(tableColumn);
                        }

                        table.AppendChild(tableColumns);
                        #endregion

                        #region [Style]
                        XmlNode style = doc.CreateElement("Style", root.NamespaceURI);

                        //<FontFamily>宋体</FontFamily>
                        XmlNode fontFamily = doc.CreateElement("FontFamily", root.NamespaceURI);
                        fontFamily.InnerText = Model.Contentfontfamily.ToString();
                        style.AppendChild(fontFamily);
                        XmlNode fontsize = doc.CreateElement("FontSize", root.NamespaceURI);
                        fontsize.InnerText = (Model.Contentfontsize / 72 * 96).ToString("0.0") + "pt";
                        style.AppendChild(fontsize);

                        table.AppendChild(style);
                        #endregion

                        #endregion
                        reportItems.AppendChild(table);
                        #endregion
                        body.AppendChild(reportItems);

                    }

                    #endregion

                    #region [PageHeader]

                    XmlNode pageHeader = doc.CreateElement("PageHeader", root.NamespaceURI);

                    XmlNode phprintOnFirstPage = doc.CreateElement("PrintOnFirstPage", root.NamespaceURI);
                    phprintOnFirstPage.InnerText = "true";
                    pageHeader.AppendChild(phprintOnFirstPage);

                    XmlNode phprintOnLastPage = doc.CreateElement("PrintOnLastPage", root.NamespaceURI);
                    phprintOnLastPage.InnerText = "true";
                    pageHeader.AppendChild(phprintOnLastPage);

                    XmlNode phheight = doc.CreateElement("Height", root.NamespaceURI);
                   // phheight.InnerText = "2.1cm";
                    phheight.InnerText = ((Model.Titlefontsize + Model.Subfontsize + Model.Contentfontsize) * 0.03527 + 1.2).ToString("0.0") + "cm";//"2.5cm"; //Czlt-2011
                    pageHeader.AppendChild(phheight);


                    XmlNode phReportItems = doc.CreateElement("ReportItems", root.NamespaceURI);

                    double widthAll = 0.0;

                    foreach (FieldMappingColumn par in mappings)
                    {
                        widthAll += Convert.ToDouble(par.ColumnWidth);
                    }

                    #region [Title(标题)]

                    XmlNode phtextbox = doc.CreateElement("Textbox", root.NamespaceURI);

                    XmlNode titleTop = doc.CreateElement("Top", root.NamespaceURI);
                    titleTop.InnerText = "0cm";
                    phtextbox.AppendChild(titleTop);

                    XmlNode titleLeft = doc.CreateElement("Left", root.NamespaceURI);
                    titleLeft.InnerText = "0cm";
                    phtextbox.AppendChild(titleLeft);

                    XmlNode titleWidth = doc.CreateElement("Width", root.NamespaceURI);
                    titleWidth.InnerText = widthAll.ToString() + "cm";
                    phtextbox.AppendChild(titleWidth);

                    XmlNode titleHeight = doc.CreateElement("Height", root.NamespaceURI);
                    titleHeight.InnerText = (Model.Titlefontsize * 0.03527+0.2).ToString() + "cm"; //"0.5cm";
                    phtextbox.AppendChild(titleHeight);

                    XmlAttribute phtextboxatt = doc.CreateAttribute("Name");
                    phtextboxatt.Value = "textboxphtitle";
                    phtextbox.Attributes.Append(phtextboxatt);

                    XmlNode phdefaultName = doc.CreateElement("rd", "DefaultName", root.Attributes[1].Value);
                    phdefaultName.InnerText = "textboxphtitle";
                    phtextbox.AppendChild(phdefaultName);


                    XmlNode phzIndex = doc.CreateElement("ZIndex", root.NamespaceURI);
                    phzIndex.InnerText = "10000";
                    phtextbox.AppendChild(phzIndex);

                    XmlNode phcanGrow = doc.CreateElement("CanGrow", root.NamespaceURI);
                    phcanGrow.InnerText = "true";
                    phtextbox.AppendChild(phcanGrow);

                    XmlNode phvalue = doc.CreateElement("Value", root.NamespaceURI);
                    phvalue.InnerText = Model.Printname.ToString();
                    phtextbox.AppendChild(phvalue);

                    XmlNode phstyle = doc.CreateElement("Style", root.NamespaceURI);

                    XmlNode phBorderStyle = doc.CreateElement("BorderStyle", root.NamespaceURI);

                    XmlNode phDefault = doc.CreateElement("Default", root.NamespaceURI);
                    phDefault.InnerText = "None";
                    phBorderStyle.AppendChild(phDefault);

                    phstyle.AppendChild(phBorderStyle);

                    XmlNode phTextAlign = doc.CreateElement("TextAlign", root.NamespaceURI);
                    phTextAlign.InnerText = Model.Titlefontstyle.ToString();
                    phstyle.AppendChild(phTextAlign);

                    XmlNode phfontFamily = doc.CreateElement("FontFamily", root.NamespaceURI);
                    phfontFamily.InnerText = Model.Titlefontfamily.ToString();//"宋体";
                    phstyle.AppendChild(phfontFamily);


                    //Czlt-2010-10-07设置表头字体大小   
                    XmlNode phFontSize = doc.CreateElement("FontSize", root.NamespaceURI);
                    phFontSize.InnerText = (Model.Titlefontsize / 72 * 96).ToString("0.0") + "pt";// "22pt";
                    phstyle.AppendChild(phFontSize);

                    //Czlt-2010-10-07设置表头字体为粗体  
                    XmlNode phFontBold = doc.CreateElement("FontWeight", root.NamespaceURI);
                    phFontBold.InnerText = "600";
                    phstyle.AppendChild(phFontBold);


                    XmlNode phpaddingLeft = doc.CreateElement("PaddingLeft", root.NamespaceURI);
                    phpaddingLeft.InnerText = "2pt";
                    phstyle.AppendChild(phpaddingLeft);

                    XmlNode phpaddingRight = doc.CreateElement("PaddingRight", root.NamespaceURI);
                    phpaddingRight.InnerText = "2pt";
                    phstyle.AppendChild(phpaddingRight);

                    XmlNode phpaddingTop = doc.CreateElement("PaddingTop", root.NamespaceURI);
                    phpaddingTop.InnerText = "2pt";
                    phstyle.AppendChild(phpaddingTop);

                    XmlNode phpaddingBottom = doc.CreateElement("PaddingBottom", root.NamespaceURI);
                    phpaddingBottom.InnerText = "2pt";
                    phstyle.AppendChild(phpaddingBottom);
                    phtextbox.AppendChild(phstyle);

                    phReportItems.AppendChild(phtextbox);

                    #endregion
                    #region【打印时间（副标题）】
                    /*****************打印时间*Start***********************************************/
                    XmlNode pfTxtTime = doc.CreateElement("Textbox", root.NamespaceURI);


                    XmlNode pftimeTop = doc.CreateElement("Top", root.NamespaceURI);
                    pftimeTop.InnerText = (Model.Titlefontsize * 0.03527+0.2).ToString() + "cm"; //"0.5cm";
                    pfTxtTime.AppendChild(pftimeTop);

                    //XmlNode pfTimeLeft = doc.CreateElement("Left", root.NamespaceURI);
                    //pfTimeLeft.InnerText = "0.0cm";
                    //pfTxtTime.AppendChild(pfTimeLeft);

                    XmlNode pfTimeWidth = doc.CreateElement("Width", root.NamespaceURI);
                    //siWidth.InnerText = widthAll.ToString() + "cm";
                    pfTimeWidth.InnerText = (widthAll / 2).ToString() + "cm";
                    pfTxtTime.AppendChild(pfTimeWidth);

                    XmlNode pfTimeHeight = doc.CreateElement("Height", root.NamespaceURI);
                    pfTimeHeight.InnerText = (Model.Subfontsize * 0.03527+0.2).ToString() + "cm";// "0.5cm";
                    pfTxtTime.AppendChild(pfTimeHeight);

                    XmlAttribute pftxtboxTimeatt = doc.CreateAttribute("Name");
                    pftxtboxTimeatt.Value = "textboxTimeFoot";
                    pfTxtTime.Attributes.Append(pftxtboxTimeatt);

                    XmlNode pfdefaultTimeName = doc.CreateElement("rd", "DefaultName", root.Attributes[1].Value);
                    pfdefaultTimeName.InnerText = "textboxTimeFoot";
                    pfTxtTime.AppendChild(pfdefaultTimeName);

                    XmlNode pfTxtTimecanGrow = doc.CreateElement("CanGrow", root.NamespaceURI);
                    pfTxtTimecanGrow.InnerText = "true";
                    pfTxtTime.AppendChild(pfTxtTimecanGrow);

                    XmlNode pfTxtTimevalue = doc.CreateElement("Value", root.NamespaceURI);
                    //pfTxtTimevalue.InnerText = "=\"打印时间:\"+Globals!DateTime.Now.ToLongDateString()+\"";
                    string dateTime = DateTime.Now.ToLongDateString();
                    pfTxtTimevalue.InnerText = "=\"打印时间:" + dateTime + "\"";
                    pfTxtTime.AppendChild(pfTxtTimevalue);

                    XmlNode pfTimeStyle = doc.CreateElement("Style", root.NamespaceURI);

                    XmlNode pfTimeBorderStyle = doc.CreateElement("BorderStyle", root.NamespaceURI);

                    XmlNode pfTimeDefault = doc.CreateElement("Default", root.NamespaceURI);
                    pfTimeDefault.InnerText = "None";
                    pfTimeBorderStyle.AppendChild(pfTimeDefault);

                    pfTimeStyle.AppendChild(pfTimeBorderStyle);

                    XmlNode pfTimeTextAlign = doc.CreateElement("TextAlign", root.NamespaceURI);
                    pfTimeTextAlign.InnerText = "Left";
                    pfTimeStyle.AppendChild(pfTimeTextAlign);

                    XmlNode pfTimefontFamily = doc.CreateElement("FontFamily", root.NamespaceURI);
                    pfTimefontFamily.InnerText = "宋体";
                    pfTimeStyle.AppendChild(pfTimefontFamily);

                    XmlNode pfTimefontsize = doc.CreateElement("FontSize", root.NamespaceURI);
                    pfTimefontsize.InnerText = (Model.Subfontsize / 72 * 96).ToString("0.0") + "pt";
                    pfTimeStyle.AppendChild(pfTimefontsize);

                    XmlNode pfTimepaddingLeft = doc.CreateElement("PaddingLeft", root.NamespaceURI);
                    pfTimepaddingLeft.InnerText = "2pt";
                    pfTimeStyle.AppendChild(pfTimepaddingLeft);

                    XmlNode pfTimepaddingRight = doc.CreateElement("PaddingRight", root.NamespaceURI);
                    pfTimepaddingRight.InnerText = "2pt";
                    pfTimeStyle.AppendChild(pfTimepaddingRight);

                    XmlNode pfTimepaddingTop = doc.CreateElement("PaddingTop", root.NamespaceURI);
                    pfTimepaddingTop.InnerText = "2pt";
                    pfTimeStyle.AppendChild(pfTimepaddingTop);

                    XmlNode pfTimepaddingBottom = doc.CreateElement("PaddingBottom", root.NamespaceURI);
                    pfTimepaddingBottom.InnerText = "2pt";
                    pfTimeStyle.AppendChild(pfTimepaddingBottom);

                    pfTxtTime.AppendChild(pfTimeStyle);

                    phReportItems.AppendChild(pfTxtTime);

                    /*****************打印时间*End*************************************************/
                    #endregion
                    #region[共多少条记录（副标题）]

                    XmlNode timetextbox = doc.CreateElement("Textbox", root.NamespaceURI);

                    XmlNode timeTop = doc.CreateElement("Top", root.NamespaceURI);
                    timeTop.InnerText = (Model.Titlefontsize * 0.03527+0.2).ToString() + "cm";// "0.5cm";
                    timetextbox.AppendChild(timeTop);

                    XmlNode timeLeft = doc.CreateElement("Left", root.NamespaceURI);
                    timeLeft.InnerText = (widthAll / 2).ToString() + "cm";
                    timetextbox.AppendChild(timeLeft);

                    XmlNode timeWidth = doc.CreateElement("Width", root.NamespaceURI);
                    timeWidth.InnerText = (widthAll / 2).ToString() + "cm";
                    timetextbox.AppendChild(timeWidth);

                    XmlNode timeHeight = doc.CreateElement("Height", root.NamespaceURI);
                    timeHeight.InnerText = (Model.Subfontsize * 0.03527+0.2).ToString() + "cm";// "0.5cm";
                    timetextbox.AppendChild(timeHeight);

                    XmlAttribute dtimetextboxatt = doc.CreateAttribute("Name");
                    dtimetextboxatt.Value = "textboxphtime";
                    timetextbox.Attributes.Append(dtimetextboxatt);

                    XmlNode dtimedefaultName = doc.CreateElement("rd", "DefaultName", root.Attributes[1].Value);
                    dtimedefaultName.InnerText = "textboxphtime";
                    timetextbox.AppendChild(dtimedefaultName);


                    XmlNode dtimezIndex = doc.CreateElement("ZIndex", root.NamespaceURI);
                    dtimezIndex.InnerText = "40000";
                    timetextbox.AppendChild(dtimezIndex);

                    XmlNode dtimecanGrow = doc.CreateElement("CanGrow", root.NamespaceURI);
                    dtimecanGrow.InnerText = "true";
                    timetextbox.AppendChild(dtimecanGrow);

                    XmlNode dtimevalue = doc.CreateElement("Value", root.NamespaceURI);
                    dtimevalue.InnerText = "=\"" + Model.Tjtime.ToString() + "\"";//"=\"当前第\"+Globals!PageNumber.ToString()+\"页,共\"+Globals!TotalPages.ToString()+\"页\"";// +printParams[2].ToString();
                    timetextbox.AppendChild(dtimevalue);

                    XmlNode dtimestyle = doc.CreateElement("Style", root.NamespaceURI);

                    XmlNode timeBorderStyle = doc.CreateElement("BorderStyle", root.NamespaceURI);

                    XmlNode timeDefault = doc.CreateElement("Default", root.NamespaceURI);
                    timeDefault.InnerText = "None";
                    timeBorderStyle.AppendChild(timeDefault);

                    dtimestyle.AppendChild(timeBorderStyle);

                    XmlNode dtimeTextAlign = doc.CreateElement("TextAlign", root.NamespaceURI);
                    dtimeTextAlign.InnerText = "Right";
                    dtimestyle.AppendChild(dtimeTextAlign);

                    XmlNode dtimefontFamily = doc.CreateElement("FontFamily", root.NamespaceURI);
                    dtimefontFamily.InnerText = Model.Subfontfamily.ToString();//"宋体";
                    dtimestyle.AppendChild(dtimefontFamily);

                    XmlNode dtimeFontSize = doc.CreateElement("FontSize", root.NamespaceURI);
                    dtimeFontSize.InnerText = (Model.Subfontsize / 72 * 96).ToString("0.0") + "pt";//"22pt";
                    dtimestyle.AppendChild(dtimeFontSize);

                    XmlNode dtimepaddingLeft = doc.CreateElement("PaddingLeft", root.NamespaceURI);
                    dtimepaddingLeft.InnerText = "2pt";
                    dtimestyle.AppendChild(dtimepaddingLeft);

                    XmlNode dtimepaddingRight = doc.CreateElement("PaddingRight", root.NamespaceURI);
                    dtimepaddingRight.InnerText = "2pt";
                    dtimestyle.AppendChild(dtimepaddingRight);

                    XmlNode dtimepaddingTop = doc.CreateElement("PaddingTop", root.NamespaceURI);
                    dtimepaddingTop.InnerText = "2pt";
                    dtimestyle.AppendChild(dtimepaddingTop);

                    XmlNode dtimepaddingBottom = doc.CreateElement("PaddingBottom", root.NamespaceURI);
                    dtimepaddingBottom.InnerText = "2pt";
                    dtimestyle.AppendChild(dtimepaddingBottom);
                    timetextbox.AppendChild(dtimestyle);

                    phReportItems.AppendChild(timetextbox);

                    #endregion

                    #region [TableHeader(表头)]

                    for (int i = 0; i < mappings.Count; i++)
                    {

                        XmlNode phttextbox = doc.CreateElement("Textbox", root.NamespaceURI);

                        XmlAttribute phttextboxatt = doc.CreateAttribute("Name");
                        phttextboxatt.Value = "textboxhead" + Convert.ToString(((i + 1)));
                        phttextbox.Attributes.Append(phttextboxatt);

                        XmlNode phtdefaultName = doc.CreateElement("rd", "DefaultName", root.Attributes[1].Value);
                        phtdefaultName.InnerText = "textboxhead" + Convert.ToString(((i + 1))); ;
                        phttextbox.AppendChild(phtdefaultName);


                        XmlNode phtTop = doc.CreateElement("Top", root.NamespaceURI);
                        phtTop.InnerText = ((Model.Titlefontsize + Model.Subfontsize) * 0.03527+0.4).ToString() + "cm"; //"1cm";
                        phttextbox.AppendChild(phtTop);

                        XmlNode phtLeft = doc.CreateElement("Left", root.NamespaceURI);

                        if (i == 0)
                        {
                            phtLeft.InnerText = "0cm";
                        }
                        else
                        {
                            double tmpleft = 0.0;

                            for (int j = 0; j < i; j++)
                            {
                                tmpleft += Convert.ToDouble(mappings[j].ColumnWidth);
                            }

                            phtLeft.InnerText = tmpleft.ToString() + "cm";
                        }

                        phttextbox.AppendChild(phtLeft);

                        XmlNode phtWidth = doc.CreateElement("Width", root.NamespaceURI);
                        phtWidth.InnerText = mappings[i].ColumnWidth + "cm";
                        phttextbox.AppendChild(phtWidth);

                        XmlNode phtHeight = doc.CreateElement("Height", root.NamespaceURI);
                        phtHeight.InnerText = (Model.Contentfontsize * 0.03527 + 1).ToString() + "cm";// "1cm";
                        phttextbox.AppendChild(phtHeight);

                        XmlNode phtzIndex = doc.CreateElement("ZIndex", root.NamespaceURI);
                        phtzIndex.InnerText = Convert.ToString((i + 1) + (mappings.Count));
                        phttextbox.AppendChild(phtzIndex);

                        XmlNode phtcanGrow = doc.CreateElement("CanGrow", root.NamespaceURI);
                        phtcanGrow.InnerText = "true";
                        phttextbox.AppendChild(phtcanGrow);

                        XmlNode pthvalue = doc.CreateElement("Value", root.NamespaceURI);
                        pthvalue.InnerText = mappings[i].ColumnName.ToString();
                        phttextbox.AppendChild(pthvalue);

                        XmlNode phtstyle = doc.CreateElement("Style", root.NamespaceURI);

                        XmlNode phtBorderStyle = doc.CreateElement("BorderStyle", root.NamespaceURI);

                        XmlNode phtDefault = doc.CreateElement("Default", root.NamespaceURI);
                        phtDefault.InnerText = "Solid";
                        phtBorderStyle.AppendChild(phtDefault);

                        phtstyle.AppendChild(phtBorderStyle);

                        XmlNode phtTextAlign = doc.CreateElement("TextAlign", root.NamespaceURI);
                        phtTextAlign.InnerText = Model.Contentfontstyle.ToString();
                        phtstyle.AppendChild(phtTextAlign);

                        XmlNode phtfontFamily = doc.CreateElement("FontFamily", root.NamespaceURI);
                        phtfontFamily.InnerText = Model.Contentfontfamily.ToString();//"宋体";
                        phtstyle.AppendChild(phtfontFamily);

                        XmlNode phtFontSize = doc.CreateElement("FontSize", root.NamespaceURI);
                        phtFontSize.InnerText = (Model.Contentfontsize / 72 * 96).ToString("0.0") + "pt";//"22pt";
                        phtstyle.AppendChild(phtFontSize);

                        XmlNode phtpaddingLeft = doc.CreateElement("PaddingLeft", root.NamespaceURI);
                        phtpaddingLeft.InnerText = "2pt";
                        phtstyle.AppendChild(phtpaddingLeft);

                        XmlNode phtpaddingRight = doc.CreateElement("PaddingRight", root.NamespaceURI);
                        phtpaddingRight.InnerText = "2pt";
                        phtstyle.AppendChild(phtpaddingRight);

                        XmlNode phtpaddingTop = doc.CreateElement("PaddingTop", root.NamespaceURI);
                        phtpaddingTop.InnerText = "2pt";
                        phtstyle.AppendChild(phtpaddingTop);

                        XmlNode phtpaddingBottom = doc.CreateElement("PaddingBottom", root.NamespaceURI);
                        phtpaddingBottom.InnerText = "2pt";
                        phtstyle.AppendChild(phtpaddingBottom);

                        phttextbox.AppendChild(phtstyle);

                        phReportItems.AppendChild(phttextbox);

                    }

                    #endregion

                    pageHeader.AppendChild(phReportItems);

                    #endregion

                    #region [PageFooter]

                    XmlNode pageFooter = doc.CreateElement("PageFooter", root.NamespaceURI);

                    XmlNode fprintOnFirstPage = doc.CreateElement("PrintOnFirstPage", root.NamespaceURI);
                    fprintOnFirstPage.InnerText = "true";
                    pageFooter.AppendChild(fprintOnFirstPage);

                    XmlNode fprintOnLastPage = doc.CreateElement("PrintOnLastPage", root.NamespaceURI);
                    fprintOnLastPage.InnerText = "true";
                    pageFooter.AppendChild(fprintOnLastPage);

                    XmlNode pfheight = doc.CreateElement("Height", root.NamespaceURI);
                    pfheight.InnerText = "1.5cm";
                    pageFooter.AppendChild(pfheight);

                    XmlNode pfReportItems = doc.CreateElement("ReportItems", root.NamespaceURI);

                    #region【Footer】
                    ///*****************Czlt-2010-10-08*打印时间*Start***********************************************/
                    //XmlNode pfTxtTime = doc.CreateElement("Textbox", root.NamespaceURI);


                    //XmlNode pftimeTop = doc.CreateElement("Top", root.NamespaceURI);
                    //pftimeTop.InnerText = "0cm";
                    //pfTxtTime.AppendChild(pftimeTop);

                    ////XmlNode pfTimeLeft = doc.CreateElement("Left", root.NamespaceURI);
                    ////pfTimeLeft.InnerText = "0.0cm";
                    ////pfTxtTime.AppendChild(pfTimeLeft);

                    //XmlNode pfTimeWidth = doc.CreateElement("Width", root.NamespaceURI);
                    ////siWidth.InnerText = widthAll.ToString() + "cm";
                    //pfTimeWidth.InnerText = "6cm";
                    //pfTxtTime.AppendChild(pfTimeWidth);

                    //XmlNode pfTimeHeight = doc.CreateElement("Height", root.NamespaceURI);
                    //pfTimeHeight.InnerText = "0.5cm";
                    //pfTxtTime.AppendChild(pfTimeHeight);

                    //XmlAttribute pftxtboxTimeatt = doc.CreateAttribute("Name");
                    //pftxtboxTimeatt.Value = "textboxTimeFoot";
                    //pfTxtTime.Attributes.Append(pftxtboxTimeatt);

                    //XmlNode pfdefaultTimeName = doc.CreateElement("rd", "DefaultName", root.Attributes[1].Value);
                    //pfdefaultTimeName.InnerText = "textboxTimeFoot";
                    //pfTxtTime.AppendChild(pfdefaultTimeName);

                    //XmlNode pfTxtTimecanGrow = doc.CreateElement("CanGrow", root.NamespaceURI);
                    //pfTxtTimecanGrow.InnerText = "true";
                    //pfTxtTime.AppendChild(pfTxtTimecanGrow);

                    //XmlNode pfTxtTimevalue = doc.CreateElement("Value", root.NamespaceURI);
                    ////pfTxtTimevalue.InnerText = "=\"打印时间:\"+Globals!DateTime.Now.ToLongDateString()+\"";
                    //string dateTime = DateTime.Now.ToLongDateString();
                    //pfTxtTimevalue.InnerText = "=\"打印时间:" + dateTime + "\"";
                    //pfTxtTime.AppendChild(pfTxtTimevalue);

                    //XmlNode pfTimeStyle = doc.CreateElement("Style", root.NamespaceURI);

                    //XmlNode pfTimeBorderStyle = doc.CreateElement("BorderStyle", root.NamespaceURI);

                    //XmlNode pfTimeDefault = doc.CreateElement("Default", root.NamespaceURI);
                    //pfTimeDefault.InnerText = "None";
                    //pfTimeBorderStyle.AppendChild(pfTimeDefault);

                    //pfTimeStyle.AppendChild(pfTimeBorderStyle);

                    //XmlNode pfTimeTextAlign = doc.CreateElement("TextAlign", root.NamespaceURI);
                    //pfTimeTextAlign.InnerText = "Center";
                    //pfTimeStyle.AppendChild(pfTimeTextAlign);

                    //XmlNode pfTimefontFamily = doc.CreateElement("FontFamily", root.NamespaceURI);
                    //pfTimefontFamily.InnerText = "宋体";
                    //pfTimeStyle.AppendChild(pfTimefontFamily);

                    //XmlNode pfTimepaddingLeft = doc.CreateElement("PaddingLeft", root.NamespaceURI);
                    //pfTimepaddingLeft.InnerText = "2pt";
                    //pfTimeStyle.AppendChild(pfTimepaddingLeft);

                    //XmlNode pfTimepaddingRight = doc.CreateElement("PaddingRight", root.NamespaceURI);
                    //pfTimepaddingRight.InnerText = "2pt";
                    //pfTimeStyle.AppendChild(pfTimepaddingRight);

                    //XmlNode pfTimepaddingTop = doc.CreateElement("PaddingTop", root.NamespaceURI);
                    //pfTimepaddingTop.InnerText = "2pt";
                    //pfTimeStyle.AppendChild(pfTimepaddingTop);

                    //XmlNode pfTimepaddingBottom = doc.CreateElement("PaddingBottom", root.NamespaceURI);
                    //pfTimepaddingBottom.InnerText = "2pt";
                    //pfTimeStyle.AppendChild(pfTimepaddingBottom);

                    //pfTxtTime.AppendChild(pfTimeStyle);

                    //pfReportItems.AppendChild(pfTxtTime);

                    /*****************Czlt-2010-10-08*打印时间*End*************************************************/
                   

                    //第几页共几张
                    XmlNode pftextbox = doc.CreateElement("Textbox", root.NamespaceURI);

                    XmlNode siTop = doc.CreateElement("Top", root.NamespaceURI);
                    siTop.InnerText = "1.0cm";
                    pftextbox.AppendChild(siTop);

                    XmlNode siLeft = doc.CreateElement("Left", root.NamespaceURI);
                    siLeft.InnerText = "0.1cm";
                    pftextbox.AppendChild(siLeft);

                    XmlNode siWidth = doc.CreateElement("Width", root.NamespaceURI);
                    siWidth.InnerText = widthAll.ToString() + "cm";
                    pftextbox.AppendChild(siWidth);

                    XmlNode siHeight = doc.CreateElement("Height", root.NamespaceURI);
                    siHeight.InnerText = "0.5cm";
                    pftextbox.AppendChild(siHeight);

                    XmlAttribute pftextboxatt = doc.CreateAttribute("Name");
                    pftextboxatt.Value = "textboxpagefoot";
                    pftextbox.Attributes.Append(pftextboxatt);

                    XmlNode pfdefaultName = doc.CreateElement("rd", "DefaultName", root.Attributes[1].Value);
                    pfdefaultName.InnerText = "textboxpagefoot";
                    pftextbox.AppendChild(pfdefaultName);


                    XmlNode pfzIndex = doc.CreateElement("ZIndex", root.NamespaceURI);
                    pfzIndex.InnerText = "1000000";
                    pftextbox.AppendChild(pfzIndex);

                    XmlNode pfcanGrow = doc.CreateElement("CanGrow", root.NamespaceURI);
                    pfcanGrow.InnerText = "true";
                    pftextbox.AppendChild(pfcanGrow);

                    XmlNode pfvalue = doc.CreateElement("Value", root.NamespaceURI);
                    pfvalue.InnerText = "=\"第 \"+Globals!PageNumber.ToString()+\" 页 共 \"+Globals!TotalPages.ToString()+\" 页\"";
                    pftextbox.AppendChild(pfvalue);

                    XmlNode pfstyle = doc.CreateElement("Style", root.NamespaceURI);

                    XmlNode pfBorderStyle = doc.CreateElement("BorderStyle", root.NamespaceURI);

                    XmlNode pfDefault = doc.CreateElement("Default", root.NamespaceURI);
                    pfDefault.InnerText = "None";
                    pfBorderStyle.AppendChild(pfDefault);

                    pfstyle.AppendChild(pfBorderStyle);

                    XmlNode pfTextAlign = doc.CreateElement("TextAlign", root.NamespaceURI);
                    pfTextAlign.InnerText = "Center";
                    pfstyle.AppendChild(pfTextAlign);

                    XmlNode pffontFamily = doc.CreateElement("FontFamily", root.NamespaceURI);
                    pffontFamily.InnerText = "宋体";
                    pfstyle.AppendChild(pffontFamily);

                    XmlNode pfpaddingLeft = doc.CreateElement("PaddingLeft", root.NamespaceURI);
                    pfpaddingLeft.InnerText = "2pt";
                    pfstyle.AppendChild(pfpaddingLeft);

                    XmlNode pfpaddingRight = doc.CreateElement("PaddingRight", root.NamespaceURI);
                    pfpaddingRight.InnerText = "2pt";
                    pfstyle.AppendChild(pfpaddingRight);

                    XmlNode pfpaddingTop = doc.CreateElement("PaddingTop", root.NamespaceURI);
                    pfpaddingTop.InnerText = "2pt";
                    pfstyle.AppendChild(pfpaddingTop);

                    XmlNode pfpaddingBottom = doc.CreateElement("PaddingBottom", root.NamespaceURI);
                    pfpaddingBottom.InnerText = "2pt";
                    pfstyle.AppendChild(pfpaddingBottom);
                    pftextbox.AppendChild(pfstyle);

                    pfReportItems.AppendChild(pftextbox);

                    //#region 【Czlt-2010-10-08-领导签字】
                    ///****************************Czlt-2010-10-08*领导签字*Start******************************************************************/
                    ////Czlt-添加领导签字
                    //XmlNode pftxtSign = doc.CreateElement("Textbox", root.NamespaceURI);

                    //XmlNode pfsiTop = doc.CreateElement("Top", root.NamespaceURI);
                    //pfsiTop.InnerText = "0cm";
                    //pftxtSign.AppendChild(pfsiTop);

                    //XmlNode pfsiLeft = doc.CreateElement("Left", root.NamespaceURI);
                    //pfsiLeft.InnerText = "14cm";
                    //pftxtSign.AppendChild(pfsiLeft);

                    //XmlNode pfsiWidth = doc.CreateElement("Width", root.NamespaceURI);
                    ////siWidth.InnerText = widthAll.ToString() + "cm";
                    //pfsiWidth.InnerText = "3.5cm";
                    //pftxtSign.AppendChild(pfsiWidth);

                    //XmlNode pfsiHeight = doc.CreateElement("Height", root.NamespaceURI);
                    //pfsiHeight.InnerText = "0.5cm";
                    //pftxtSign.AppendChild(pfsiHeight);

                    //XmlAttribute pftxtboxSignatt = doc.CreateAttribute("Name");
                    //pftxtboxSignatt.Value = "textboxSignFoot";
                    //pftxtSign.Attributes.Append(pftxtboxSignatt);

                    //XmlNode pfdefaultSignName = doc.CreateElement("rd", "DefaultName", root.Attributes[1].Value);
                    //pfdefaultSignName.InnerText = "textboxSignFoot";
                    //pftxtSign.AppendChild(pfdefaultSignName);

                    //XmlNode pfTxtSigncanGrow = doc.CreateElement("CanGrow", root.NamespaceURI);
                    //pfTxtSigncanGrow.InnerText = "true";
                    //pftxtSign.AppendChild(pfTxtSigncanGrow);

                    //XmlNode pfTxtSignvalue = doc.CreateElement("Value", root.NamespaceURI);
                    //pfTxtSignvalue.InnerText = "=\"领导签字:\"";
                    //pftxtSign.AppendChild(pfTxtSignvalue);

                    //XmlNode pfSignStyle = doc.CreateElement("Style", root.NamespaceURI);

                    //XmlNode pfsignBorderStyle = doc.CreateElement("BorderStyle", root.NamespaceURI);

                    //XmlNode pfsignDefault = doc.CreateElement("Default", root.NamespaceURI);
                    //pfsignDefault.InnerText = "None";
                    //pfsignBorderStyle.AppendChild(pfsignDefault);

                    //pfSignStyle.AppendChild(pfsignBorderStyle);

                    //XmlNode pfsignTextAlign = doc.CreateElement("TextAlign", root.NamespaceURI);
                    //pfsignTextAlign.InnerText = "Center";
                    //pfSignStyle.AppendChild(pfsignTextAlign);

                    //XmlNode pfsignfontFamily = doc.CreateElement("FontFamily", root.NamespaceURI);
                    //pfsignfontFamily.InnerText = "宋体";
                    //pfSignStyle.AppendChild(pfsignfontFamily);

                    //XmlNode pfsignpaddingLeft = doc.CreateElement("PaddingLeft", root.NamespaceURI);
                    //pfsignpaddingLeft.InnerText = "2pt";
                    //pfSignStyle.AppendChild(pfsignpaddingLeft);

                    //XmlNode pfsignpaddingRight = doc.CreateElement("PaddingRight", root.NamespaceURI);
                    //pfsignpaddingRight.InnerText = "2pt";
                    //pfSignStyle.AppendChild(pfsignpaddingRight);

                    //XmlNode pfsignpaddingTop = doc.CreateElement("PaddingTop", root.NamespaceURI);
                    //pfsignpaddingTop.InnerText = "2pt";
                    //pfSignStyle.AppendChild(pfsignpaddingTop);

                    //XmlNode pfsignpaddingBottom = doc.CreateElement("PaddingBottom", root.NamespaceURI);
                    //pfsignpaddingBottom.InnerText = "2pt";
                    //pfSignStyle.AppendChild(pfsignpaddingBottom);

                    //pftxtSign.AppendChild(pfSignStyle);

                    //pfReportItems.AppendChild(pftxtSign);
                    ///*********************************Czlt-2010-10-08*领导签字*End*************************************************************/
                    //#endregion
                    #endregion
                    #region【NewFooter】
                    string[] footer =Model.Signcontent.ToString().Split(',');
                    for (int i = 0; i < footer.Length; i++)
                    {
                        XmlNode pftxtSign = doc.CreateElement("Textbox", root.NamespaceURI);

                        XmlNode pfsiTop = doc.CreateElement("Top", root.NamespaceURI);
                        pfsiTop.InnerText = "0cm";
                        pftxtSign.AppendChild(pfsiTop);

                        XmlNode pfsiLeft = doc.CreateElement("Left", root.NamespaceURI);
                        pfsiLeft.InnerText = (widthAll / footer.Length * i).ToString() + "cm";
                        pftxtSign.AppendChild(pfsiLeft);

                        XmlNode pfsiWidth = doc.CreateElement("Width", root.NamespaceURI);
                        //siWidth.InnerText = widthAll.ToString() + "cm";
                        pfsiWidth.InnerText = (widthAll / footer.Length).ToString() + "cm";
                        pftxtSign.AppendChild(pfsiWidth);

                        XmlNode pfsiHeight = doc.CreateElement("Height", root.NamespaceURI);
                       // pfsiHeight.InnerText = "0.4cm";
                        pfsiHeight.InnerText = "0.0cm";
                        pftxtSign.AppendChild(pfsiHeight);

                        XmlAttribute pftxtboxSignatt = doc.CreateAttribute("Name");
                        pftxtboxSignatt.Value = "textboxSignFoot"+i.ToString();
                        pftxtSign.Attributes.Append(pftxtboxSignatt);

                        XmlNode pfdefaultSignName = doc.CreateElement("rd", "DefaultName", root.Attributes[1].Value);
                        pfdefaultSignName.InnerText = "textboxSignFoot" + i.ToString();
                        pftxtSign.AppendChild(pfdefaultSignName);

                        XmlNode pfTxtSigncanGrow = doc.CreateElement("CanGrow", root.NamespaceURI);
                        pfTxtSigncanGrow.InnerText = "true";
                        pftxtSign.AppendChild(pfTxtSigncanGrow);

                        XmlNode pfTxtSignvalue = doc.CreateElement("Value", root.NamespaceURI);
                        pfTxtSignvalue.InnerText =  "=\"" + footer[i].ToString() + "\"";
                        pftxtSign.AppendChild(pfTxtSignvalue);

                        XmlNode pfSignStyle = doc.CreateElement("Style", root.NamespaceURI);

                        XmlNode pfsignBorderStyle = doc.CreateElement("BorderStyle", root.NamespaceURI);

                        XmlNode pfsignDefault = doc.CreateElement("Default", root.NamespaceURI);
                        pfsignDefault.InnerText = "None";
                        pfsignBorderStyle.AppendChild(pfsignDefault);

                        pfSignStyle.AppendChild(pfsignBorderStyle);

                        XmlNode pfsignTextAlign = doc.CreateElement("TextAlign", root.NamespaceURI);
                        pfsignTextAlign.InnerText = Model.Signfontstyle.ToString();
                        pfSignStyle.AppendChild(pfsignTextAlign);

                        XmlNode pfsignfontFamily = doc.CreateElement("FontFamily", root.NamespaceURI);
                        pfsignfontFamily.InnerText = Model.Signfontfamily.ToString();
                        pfSignStyle.AppendChild(pfsignfontFamily);

                        XmlNode pfsignfontsize = doc.CreateElement("FontSize", root.NamespaceURI);
                        //pfsignfontsize.InnerText = (Model.Signfontsize / 72 * 96).ToString("0.0") + "pt";
                        pfsignfontsize.InnerText = (Model.Signfontsize / 72 * 86).ToString("0.0") + "pt";
                        pfSignStyle.AppendChild(pfsignfontsize);

                        XmlNode pfsignpaddingLeft = doc.CreateElement("PaddingLeft", root.NamespaceURI);
                        pfsignpaddingLeft.InnerText = "2pt";
                        pfSignStyle.AppendChild(pfsignpaddingLeft);

                        XmlNode pfsignpaddingRight = doc.CreateElement("PaddingRight", root.NamespaceURI);
                        pfsignpaddingRight.InnerText = "2pt";
                        pfSignStyle.AppendChild(pfsignpaddingRight);

                        XmlNode pfsignpaddingTop = doc.CreateElement("PaddingTop", root.NamespaceURI);
                        pfsignpaddingTop.InnerText = "2pt";
                        pfSignStyle.AppendChild(pfsignpaddingTop);

                        XmlNode pfsignpaddingBottom = doc.CreateElement("PaddingBottom", root.NamespaceURI);
                        pfsignpaddingBottom.InnerText = "2pt";
                        pfSignStyle.AppendChild(pfsignpaddingBottom);

                        pftxtSign.AppendChild(pfSignStyle);

                        pfReportItems.AppendChild(pftxtSign);
                    }




                   
                    #endregion
                    //dtableCell.AppendChild(dtextbox);

                    //XmlNode dreportItems = doc.CreateElement("ReportItems", root.NamespaceURI);
                   

                    pageFooter.AppendChild(pfReportItems);

                    #endregion

                    root.AppendChild(pageHeader);
                    root.AppendChild(pageFooter);
                    root.AppendChild(dataSources);
                    root.AppendChild(dses);
                }
            }
            catch(Exception e)
            {
                MessageBox.Show("发生错误,错误信息[" + e.Message + "]", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            return doc;

        }

        /// <summary>
        /// 处理DataTable,把DataTable里面的true 或 false 换成文字
        /// </summary>
        /// <param name="dt">要处理的DataTable</param>
        /// <returns>处理后的DataTable</returns>
        private DataTable ProcessDataTable(DataTable dt)
        {
            try
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    bool flag = false;
                    DataTable dtClone = dt.Clone();
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
            catch(Exception e)
            {
                MessageBox.Show("发生错误,错误信息[" + e.Message + "]", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
        }

        private void FormPrint_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isLoaded)
            {
                MessageBox.Show("数据加载中,请勿关闭!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Cancel = true;
            }
        }

        private void PrintView_RenderingComplete(object sender, RenderingCompleteEventArgs e)
        {
            isLoaded = true;


            if (autoPrint)
            {

                ThreadStart ts = new ThreadStart(AutoPrint);

                Thread th = new Thread(ts);

                th.Start();

                //this.Hide(); 
                //this.WindowState = FormWindowState.Minimized;

                th.Join(6000);

                PrintView.PrintDialog();

                th.Abort();

                //SendKeys.Send("%(P)");

                this.Close();
            }

            //Thread.Sleep(1000);


            //th.Start();
        }

        /// <summary>
        /// 送自动打印按键
        /// </summary>
        private void AutoPrint()
        {
            SendKeys.SendWait("%(P)");
            //MessageBox.Show("zhengzaizidongdayin");
        }

        #endregion


       

        #region [ IPrintComponent 成员] 

        #region[DataGridViewKJ128控件   屏蔽]
        ///// <summary>
        ///// 调打印窗体
        ///// </summary>
        ///// <param name="dgv">DataGridView控件</param>
        ///// <param name="title">打印标题</param>
        //public void CallPrintForm(DataGridViewKJ128 dgv, string title, string sum)
        //{
        //    try
        //    {
        //        if (sum == "AutoPrint")
        //        {
        //            this.autoPrint = true;
        //        }
        //        if (Model == null)
        //        {
        //            MessageBox.Show("打印模板错误，请重新设置打印参数", "提示");
        //            return;
        //        }
        //        if (dgv != null && dgv.DataSource != null && dgv.Rows.Count > 0)
        //        {
        //            if (mapping == null)
        //                mapping = new Collection<FieldMappingColumn>();

        //            if (mapping.Count > 0)
        //                mapping.Clear();

        //            int sumlen = 0;
        //            double pagewidth = Convert.ToDouble(Model.Paperwidth) - Convert.ToDouble(Model.Paperleft) - Convert.ToDouble(Model.Paperright);// -1;
        //            if (Model.Columnswidth != "" && Model.Printtable.TableName != "A_InitialData")
        //            {
        //                string[] str = Model.Columnswidth.ToString().Split(',');
        //                string[] columnsname = Model.Columns.ToString().Split(',');
        //                if (dgv.ColumnCount > 0)
        //                {
        //                    foreach (string width in str)
        //                    {
        //                        sumlen += Convert.ToInt32(width);
        //                    }
        //                }

        //                double unit = pagewidth / Convert.ToDouble(sumlen);

        //                if (dgv.ColumnCount > 0)
        //                {
                          
        //                    for (int i = 0; i < columnsname.Length; i++)
        //                    {
        //                        FieldMappingColumn field = new FieldMappingColumn();
        //                        field.ColumnName = dgv.Columns[columnsname[i]].HeaderText.ToString();
        //                        field.Filed = dgv.Columns[columnsname[i]].DataPropertyName;
        //                        field.ColumnWidth = Convert.ToDouble((unit * Convert.ToDouble(str[i]))).ToString("0.0");
        //                        mapping.Add(field);
        //                    }

        //                }
        //            }
        //            else
        //            {
        //                if (dgv.ColumnCount > 0)
        //                {
        //                    //if (dgv.Columns[0].GetType().ToString() == "System.Windows.Forms.DataGridViewCheckBoxColumn")
        //                    //{
        //                    //    dgv.Columns.Remove(dgv.Columns[0].Name);
        //                    //}

        //                    sumlen = 200 * Model.Printtable.Columns.Count;
                            
        //                    double unit = pagewidth / Convert.ToDouble(sumlen);
        //                    for (int i = 0; i < Model.Printtable.Columns.Count; i++)
        //                    {
        //                        FieldMappingColumn field = new FieldMappingColumn();
        //                        field.ColumnName = dgv.Columns[Model.Printtable.Columns[i].ColumnName].HeaderText.ToString();
        //                        field.Filed = dgv.Columns[Model.Printtable.Columns[i].ColumnName].DataPropertyName;
        //                        field.ColumnWidth = Convert.ToDouble((unit * Convert.ToDouble(200))).ToString("0.0");
        //                        mapping.Add(field);
        //                    }
        //                }
        //            }
        //            //19


        //            int count = mapping.Count;

        //            DataTable dtResult = null;
        //            if (dgv.DataSource != null)
        //            {
        //                if (dgv.DataSource.GetType().ToString() == "System.Data.DataView")
        //                {
        //                    dtResult = ProcessDataTable(((DataView)dgv.DataSource).Table);
        //                }
        //                else
        //                {
        //                    dtResult = ProcessDataTable((DataTable)dgv.DataSource);
        //                }


        //                object[] para = new object[] { "MyDataSet", title, sum };


        //                //if (dtResult != null && dtResult.Rows.Count > 0)
        //                //{
        //                //调用
        //                CallPrintForm(dtResult, mapping, para);
        //                //}
        //                //else
        //                //{
        //                //    MessageBox.Show("无数据信息,不能打印!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //                //}
        //            }

        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        MessageBox.Show("发生错误,错误信息:[" + e.Message + "]", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //    }

        //}

        //public void CallPrintForm(DataGridViewKJ128 dgv, string title, string sum, bool isAutoPrint)
        //{
           
        //    this.autoPrint = true;
        //    CallPrintForm(dgv, title, sum);

        //}
        #endregion
        public void CallPrintForm(DataGridView dgv, string title, string sum, bool isAutoPrint)
        {
            this.autoPrint = true;
            CallPrintForm(dgv, title, sum);

        }

        public void CallPrintForm(DataGridView dgv, string title, string sum)
        {
            try
            {
                if (sum == "AutoPrint")
                {
                    this.autoPrint = true;
                }
                if (Model == null)
                {
                    MessageBox.Show("打印模板错误，请重新设置打印参数", "提示");
                    return;
                }
                if (dgv != null && dgv.DataSource !=null && dgv.Rows.Count > 0)
                {
                    if (mapping == null)
                        mapping = new Collection<FieldMappingColumn>();

                    if (mapping.Count > 0)
                        mapping.Clear();

                    int sumlen = 0;
                    //页宽  总页宽-左右边宽
                    double pagewidth = Convert.ToDouble(Model.Paperwidth) - Convert.ToDouble(Model.Paperleft) - Convert.ToDouble(Model.Paperright) ;// -1;

                    List<string> columnswidths = Model.Columnswidth;//列宽集合
                    List<string> columnsname = Model.Columns;//列名集合
                       
                    //正常打印
                    if (Model.Columnswidth.Count != 0 && Model.Printtable.TableName != "A_InitialData")
                    {
                      
                        if (dgv.ColumnCount > 0)
                        {
                            //获取总宽度
                            foreach (string width in columnswidths)
                            {
                                sumlen += Convert.ToInt32(width);
                            }
                        }
                        //获取单元宽度
                        double unit = pagewidth / Convert.ToDouble(sumlen);

                        if (dgv.ColumnCount > 0)
                        {
                            for (int i = 0; i < columnsname.Count; i++)
                            {
                                //循环注入模板中
                                FieldMappingColumn field = new FieldMappingColumn();
                                field.ColumnName = dgv.Columns[columnsname[i]].HeaderText.ToString();
                                field.Filed = dgv.Columns[columnsname[i]].DataPropertyName;
                                field.ColumnWidth = Convert.ToDouble((unit * Convert.ToDouble(columnswidths[i]))).ToString("0.00");
                                mapping.Add(field);
                            }

                        }
                    }
                    else//无模板直接打印
                    {
                        if (dgv.ColumnCount > 0)
                        {
                            if (columnswidths.Count != Model.Printtable.Columns.Count)//判断如果勾选的列数和实际列数是否相等
                            {
                                columnswidths = new List<string>();
                                columnsname = new List<string>();
                                for (int i = 0; i < Model.Printtable.Columns.Count; i++)
                                {
                                    columnswidths.Add("1");
                                    columnsname.Add(Model.Printtable.Columns[i].ColumnName);
                                }
                            }
                            //获取总宽度
                            foreach (string width in columnswidths)
                            {
                                sumlen += Convert.ToInt32(width);
                            }

                            //获取单元宽度
                            double unit = pagewidth / Convert.ToDouble(sumlen);
                            for (int i = 0; i < Model.Printtable.Columns.Count; i++)
                            {
                                //循环注入模板中
                                FieldMappingColumn field = new FieldMappingColumn();
                                field.ColumnName = dgv.Columns[Model.Printtable.Columns[i].ColumnName].HeaderText.ToString();
                                field.Filed = dgv.Columns[Model.Printtable.Columns[i].ColumnName].DataPropertyName;
                                field.ColumnWidth = Convert.ToDouble((unit * Convert.ToDouble(columnswidths[i]))).ToString("0.00");
                                mapping.Add(field);
                            }
                        }
                    }
                    //19
                    
                    DataTable dtResult = null;
                    if (dgv.DataSource != null)
                    {
                        if (dgv.DataSource.GetType().ToString() == "System.Data.DataView")
                        {
                            dtResult = ProcessDataTable(((DataView)dgv.DataSource).Table);
                        }
                        else
                        {
                            dtResult = ProcessDataTable((DataTable)dgv.DataSource);
                        }


                        object[] para = new object[] { "MyDataSet", title, sum };


                        //if (dtResult != null && dtResult.Rows.Count > 0)
                        //{
                        //调用
                        CallPrintForm(dtResult, mapping, para);
                        //}
                        //else
                        //{
                        //    MessageBox.Show("无数据信息,不能打印!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        //}
                    }
                }
                else
                {
                    MessageBox.Show("没有数据生成，请重新查询", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("发生错误,错误信息:[" + e.Message + "]", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        #endregion

        #region [ FormLoad事件 ]

        private void frmPrint_Load(object sender, EventArgs e)
        {
            try
            {
                this.PrintView.SetDisplayMode(DisplayMode.PrintLayout);
                //this.PrintView.RefreshReport();
                
                //isLoaded = true;
            }
            catch(Exception ex )
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion


       

    }
}