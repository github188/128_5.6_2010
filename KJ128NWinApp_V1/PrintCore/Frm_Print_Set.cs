using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using KJ128NInterfaceShow;

namespace PrintCore
{
    public partial class Frm_Print_Set : Form
    {
        #region【预定义参数】
        private string tableName = string.Empty;
        private string PrintTableName = string.Empty;
        PrintModel model = null;

        #endregion

        #region【初始化窗体】
        public Frm_Print_Set(PrintModel modes, string TableName)
        {
            InitializeComponent();
            model = modes;
            PrintTableName = TableName;
            tableName = modes.Printtable.TableName.ToString();
        }
       
        private void Frm_Print_Set_Load(object sender, EventArgs e)
        {
            //model = GetModel.getMode(model, tableName);
            InitializeForm();
        }
        #endregion

        #region【加载配置文件】
        
        /// <summary>
        /// 初始化纸张属性
        /// </summary>
        private void SetPageSize(string width, string height)
        {
            if (width + "," + height == "21,29.7")
                cmbPageSize.SelectedIndex = 0;
            else if (width + "," + height == "29.7,21")
                cmbPageSize.SelectedIndex = 1;
            else if (width + "," + height == "29.7,42")
                cmbPageSize.SelectedIndex = 2;
            else if (width + "," + height == "42,29.7")
                cmbPageSize.SelectedIndex = 3;
            else
                cmbPageSize.SelectedIndex = 0;

        }
        /// <summary>
        /// 根据父控件和控件名找到控件
        /// </summary>
        private Control FindControl(Control c, string controlName)
        {

            foreach (Control cc in c.Controls)
            {
                if (cc.Name == controlName)
                    return cc;
            }
            return null;

        }

        #region[获得对齐方式]
        private string cmbName(string style)
        {
            switch (style)
            {
                case "Center": return "居中";
                case "Left": return "靠左";
                case "Right": return "靠右";
                default: return "居中";
            }
        }
        private string getcmbName(string style)
        {
            switch (style)
            {
                case "居中": return "Center";
                case "靠左": return "Left";
                case "靠右": return "Right";
                default: return "Center";
            }
        }
        #endregion

        /// <summary>
        /// 获得字号名字
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        private string FontSizeName(string size)
        {
            switch (size)
            {
                case "42": return "初号";
                case "36": return "小初";
                case "26.25": return "一号";
                case "24": return "小一";
                case "21.75": return "二号";
                case "18": return "小二";
                case "15.75": return "三号";
                case "15": return "小三";
                case "14.25": return "四号";
                case "12": return "小四";
                case "10.5": return "五号";
                case "9": return "小五";
                case "7.5": return "六号";
                case "6.75": return "小六";
                case "5.25": return "七号";
                default: return size;
            }
        }
        /// <summary>
        /// 给控件初始化值
        /// </summary>
        private void InitializeForm()
        {
            if (model == null)
            {
                MessageBox.Show("加载打印配置文件出错,打印失败", "提示");
                return;
            }
            //表格名称
            if (model.Printname.ToString().Trim() == "")
                txtPrintName.Text = PrintTableName;
            else
                txtPrintName.Text = model.Printname.ToString();
            
            //字体显示
            lblTitle.Text = "字体：'" + model.Titlefontfamily.ToString() + "'  字号：'" + FontSizeName(model.Titlefontsize.ToString()) + "'";
            lblFTitle.Text = "字体：'" + model.Subfontfamily.ToString() + "'  字号：'" + FontSizeName(model.Subfontsize.ToString()) + "'";
            lblContent.Text = "字体：'" + model.Contentfontfamily.ToString() + "'  字号：'" + FontSizeName(model.Contentfontsize.ToString()) + "'";
            lblSigh.Text = "字体：'" + model.Signfontfamily.ToString() + "'  字号：'" + FontSizeName(model.Signfontsize.ToString()) + "'";

            //对齐方式显示
            cmbTitle.Text = cmbName(model.Titlefontstyle.ToString());
            cmbSubTitle.Text = cmbName(model.Subfontstyle.ToString());
            cmbContent.Text = cmbName(model.Contentfontstyle.ToString());
            cmbSign.Text = cmbName(model.Signfontstyle.ToString());

            //设置页面
            SetPageSize(model.Paperwidth, model.Paperheight);
            num1.Text = model.Papertop.ToString();
            num2.Text = model.Paperbottom.ToString();
            num3.Text = model.Paperleft.ToString();
            num4.Text = model.Paperright.ToString();

            //设置签名栏
            string[] str = model.Signcontent.ToString().Trim().Split(',');
            for (int i = 1; i < str.Length + 1; i++)
            {
                ((TextBox)(FindControl(groupBox1, "textBox" + i.ToString()))).Text = str[i - 1].ToString();
            }
            //设置显示表格信息

            if (model.Printtable != null)
            {
                BindingGrid(Dgv_Main);
            }

        }
        #endregion

        /// <summary>
        /// 绑定datagridview
        /// </summary>
        /// <param name="dv1"></param>
        /// <param name="grid"></param>
        private void BindingGrid(DataGridView Dgv_Main)//****
        {
            Dgv_Main.DataSource = model.Printtable;

            foreach (DataGridViewColumn col in Dgv_Main.Columns)
            {
                for (int i = 0; i < model.Columnname.Count; i++)
                {
                    if (col.Name == model.Columnname[i].ToString())
                    {
                        col.HeaderText = model.Columntext[i].ToString();
                    }
                }
            }
            //判断是否有配置信息
            if (model.Columns.Count != 0 && tableName != "Table" )
            {
                
                if (Dgv_Main.Columns.Count > 12)
                {
                    panel2.Enabled = false;
                    panel2.Visible = false;
                }
                else
                {
                    int i = 0;
                    foreach (DataGridViewColumn col in Dgv_Main.Columns)
                    {

                        i++;
                        //为checkbox赋值
                        ((CheckBox)(FindControl(panel2, "checkBox" + i.ToString()))).Visible = true;
                        ((CheckBox)(FindControl(panel2, "checkBox" + i.ToString()))).Text = col.HeaderText.ToString();
                        ((CheckBox)(FindControl(panel2, "checkBox" + i.ToString()))).Tag = col.Name.ToString();
                        col.Visible = true;
                        if (!model.Columns.Contains(col.Name.ToString().Trim()))
                        {
                            //选中checkbox
                            ((CheckBox)(FindControl(panel2, "checkBox" + i.ToString()))).Checked = false;
                            col.Visible = false;
                        }
                    }
                }
                //设置grid列索引
                //string[] tempStr = model.Columns.Split(',');
                //for (int i = 0; i < Dgv_Main.Columns.Count; i++)
                //{
                //    if (i < tempStr.Length)
                //        Dgv_Main.Columns[tempStr[i].ToString()].DisplayIndex = i;
                //}
                //string[] str = model.Columnswidth.ToString().Trim().Split(',');
                if (tableName == "A_InitialData" && model.Columnswidth.Count != Dgv_Main.Columns.Count)
                {
                    Dgv_Main.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                else
                {
                    //设置每列的宽度
                    for (int m = 0; m < model.Columnswidth.Count; m++)
                    {
                        for (int j = 0; j < model.Columnswidth.Count; j++)
                        {
                            if (Dgv_Main.Columns[j].DisplayIndex == m)
                            {
                                Dgv_Main.Columns[j].Width = Convert.ToInt32(model.Columnswidth[m].ToString());
                                break;
                            }
                        }
                        // Dgv_Main.Columns[m].Width = Convert.ToInt32(str[m].ToString());
                    }
                }
            }
            else
            {
                for (int i = 1; i < Dgv_Main.Columns.Count + 1; i++)
                {
                    if (Dgv_Main.Columns.Count > 12)//大于12列则全部显示
                    {
                        panel2.Enabled = false;
                        panel2.Visible = false;
                        panel2.Height = 0;
                        panel1.Dock = DockStyle.Fill;
                        break;
                    }
                    ((CheckBox)(FindControl(panel2, "checkBox" + i.ToString()))).Visible = true;
                    ((CheckBox)(FindControl(panel2, "checkBox" + i.ToString()))).Text = Dgv_Main.Columns[i - 1].HeaderText.ToString();
                    ((CheckBox)(FindControl(panel2, "checkBox" + i.ToString()))).Tag = Dgv_Main.Columns[i - 1].Name.ToString();

                }
                Dgv_Main.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            
        }
       

        #region【保存打印配置信息】
        public void btnSave_Click(object sender, EventArgs e)
        {
            SaveModel();
            SaveConfigXml();
            //MyEvent(model);
            //this.DialogResult = DialogResult.Yes;
            this.Close();
        }
        /// <summary>
        /// 保存xml文件
        /// </summary>
        private void SaveConfigXml()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(Application.StartupPath.ToString() + "\\PrintSetModel\\" + tableName + ".xml");
            //表格名称
            doc.SelectSingleNode("/PrintSet/TableName").InnerText = model.Printname.ToString();

            //标题栏字体
            doc.SelectSingleNode("/PrintSet/Font/TitleFont").InnerText = model.Titlefontfamily + "," + model.Titlefontsize.ToString() + "," + model.Titlefontstyle;


            //副标题字体
            doc.SelectSingleNode("/PrintSet/Font/subTitleFont").InnerText = model.Subfontfamily + "," + model.Subfontsize.ToString() + "," + model.Subfontstyle;


            //表格字体
            doc.SelectSingleNode("/PrintSet/Font/ContentFont").InnerText = model.Contentfontfamily + "," + model.Contentfontsize.ToString() + "," + model.Contentfontstyle;


            //签名栏字体
            doc.SelectSingleNode("/PrintSet/Font/SignFont").InnerText = model.Signfontfamily + "," + model.Signfontsize.ToString() + "," + model.Signfontstyle;


            //纸张大小
            doc.SelectSingleNode("/PrintSet/PageSet/PageSize").InnerText = model.Paperwidth.ToString() + "," + model.Paperheight.ToString();

            //纸张边距
            doc.SelectSingleNode("/PrintSet/PageSet/Margin").InnerText = model.Papertop.ToString() + "," + model.Paperbottom.ToString() + "," + model.Paperleft + "," + model.Paperright;

            //签名栏内容
            doc.SelectSingleNode("/PrintSet/Sign/LeaderList").InnerText = model.Signcontent.ToString();

            //表格列名集合
            string temp = string.Empty;
            foreach (string temps in model.Columns)
            {
                temp += "," + temps;
            }
            doc.SelectSingleNode("/PrintSet/Content/Columns").InnerText = temp.Remove(0, 1);

            //表格列宽集合
            temp = string.Empty;
            foreach (string temps in model.Columnswidth)
            {
                temp += "," + temps;
            }
            doc.SelectSingleNode("/PrintSet/Content/Width").InnerText = temp.Remove(0, 1);
            doc.Save(Application.StartupPath.ToString() + "\\PrintSetModel\\" + tableName + ".xml");
        }
        /// <summary>
        /// 保存model
        /// </summary>
        private void SaveModel()
        {
            if (txtPrintName.Text.Trim() != "")
                model.Printname = txtPrintName.Text.Trim();
            else
                model.Printname = PrintTableName.ToString();
            //字体属性
            model.Titlefontstyle = getcmbName(cmbTitle.Text.ToString().Trim());
            model.Subfontstyle = getcmbName(cmbSubTitle.Text.ToString().Trim());
            model.Contentfontstyle = getcmbName(cmbContent.Text.ToString().Trim());
            model.Signfontstyle = getcmbName(cmbSign.Text.ToString().Trim());
            //纸张属性
            SetModelPaper(cmbPageSize.SelectedIndex);
            model.Papertop = num1.Text.ToString().Trim();
            model.Paperbottom = num2.Text.ToString().Trim();
            model.Paperleft = num3.Text.ToString().Trim();
            model.Paperright = num4.Text.ToString().Trim();
            //签名栏
            model.Signcontent = textBox1.Text.ToString().Trim() + "," + textBox2.Text.ToString().Trim() + "," + textBox3.Text.ToString().Trim() + "," + textBox4.Text.ToString().Trim();

            //表格列数
            model.Columns = new List<string>();
            //表格宽度
            model.Columnswidth = new List<string>();
            int index = 0;
            //foreach (DataGridViewColumn dc in Dgv_Main.Columns)
            //{
            //    if (dc.Visible == true)
            //    {

            //        dc.DisplayIndex = index;
            //        index++;
            //        model.Columns += "," + dc.HeaderText.ToString();
            //        model.Columnswidth += "," + dc.Width.ToString();


            //    }
            //}

            int abort = 0;
            for (int i = 0; i < Dgv_Main.Columns.Count; i++)
            {
                abort = 0;
                foreach (DataGridViewColumn dc in Dgv_Main.Columns)
                {
                    if (dc.Visible == true)
                    {
                        if (dc.DisplayIndex == index)
                        {
                            index++;
                            model.Columns.Add(dc.Name.ToString());
                            model.Columnswidth.Add(dc.Width.ToString());
                            abort = 1;
                            break;
                        }
                    }
                    
                }
                if (abort == 0)
                    index++;
            }
            

            //try
            //{
            //    model.Columns = model.Columns.Remove(0, 1);
            //    model.Columnswidth = model.Columnswidth.Remove(0, 1);
            //}
            //catch
            //{
            //    model.Columns = "";
            //    model.Columnswidth = "";
            //}

        }

        /// <summary>
        /// 设置纸张大小
        /// </summary>
        private void SetModelPaper(int index)
        {
            switch (index)
            {
                case 0:
                    {
                        model.Paperwidth = "21";
                        model.Paperheight = "29.7";
                    }
                    break;
                case 1:
                    {
                        model.Paperwidth = "29.7";
                        model.Paperheight = "21";
                    }
                    break;
                case 2:
                    {
                        model.Paperwidth = "29.7";
                        model.Paperheight = "42";
                    }
                    break;
                case 3:
                    {
                        model.Paperwidth = "42";
                        model.Paperheight = "29.7";
                    }
                    break;
                default:
                    {
                        model.Paperwidth = "21";
                        model.Paperheight = "29.7";
                    } break;
            }
        }
        #endregion



        #region【按钮事件】
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }
        private void btnTitle_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            fd.ShowApply = false;
            fd.ShowColor = false;
            fd.ShowEffects = false;
            fd.MaxSize = 42;
            fd.MinSize = 5;
            fd.Font = new Font(model.Titlefontfamily.ToString(), model.Titlefontsize);
            if (fd.ShowDialog() == DialogResult.OK)
            {
                model.Titlefontfamily = fd.Font.FontFamily.Name.ToString();
                model.Titlefontsize = fd.Font.Size;
                lblTitle.Text = "字体：'" + model.Titlefontfamily.ToString() + "'  字号：'" + FontSizeName(model.Titlefontsize.ToString()) + "'";
            }
        }


        private void btnFTitle_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            fd.ShowApply = false;
            fd.ShowColor = false;
            fd.ShowEffects = false;
            fd.MaxSize = 42;
            fd.MinSize = 5;
            fd.Font = new Font(model.Subfontfamily.ToString(), model.Subfontsize);
            if (fd.ShowDialog() == DialogResult.OK)
            {
                model.Subfontfamily = fd.Font.FontFamily.Name.ToString();
                model.Subfontsize = fd.Font.Size;
                lblFTitle.Text = "字体：'" + model.Subfontfamily.ToString() + "'  字号：'" + FontSizeName(model.Subfontsize.ToString()) + "'";
            }
        }

        private void btnBody_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            fd.ShowApply = false;
            fd.ShowColor = false;
            fd.ShowEffects = false;
            fd.MaxSize = 42;
            fd.MinSize = 5;
            fd.Font = new Font(model.Contentfontfamily.ToString(), model.Contentfontsize);
            if (fd.ShowDialog() == DialogResult.OK)
            {
                model.Contentfontfamily = fd.Font.FontFamily.Name.ToString();
                model.Contentfontsize = fd.Font.Size;
                lblContent.Text = "字体：'" + model.Contentfontfamily.ToString() + "'  字号：'" + FontSizeName(model.Contentfontsize.ToString()) + "'";
            }
        }

        private void BtnSigh_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            fd.ShowApply = false;
            fd.ShowColor = false;
            fd.ShowEffects = false;
            fd.MaxSize = 42;
            fd.MinSize = 5;
            fd.Font = new Font(model.Signfontfamily.ToString(), model.Signfontsize);
            if (fd.ShowDialog() == DialogResult.OK)
            {
                model.Signfontfamily = fd.Font.FontFamily.Name.ToString();
                model.Signfontsize = fd.Font.Size;
                lblSigh.Text = "字体：'" + model.Signfontfamily.ToString() + "'  字号：'" + FontSizeName(model.Signfontsize.ToString()) + "'";
            }
        }

        private void checkBox_Click(object sender, EventArgs e)
        {
            CheckBox ck = sender as CheckBox;
            if (ck.Checked)
            {
                Dgv_Main.Columns[ck.Tag.ToString()].Visible = true;

            }
            else
            {
                Dgv_Main.Columns[ck.Tag.ToString()].Visible = false;
            }

        }
        #endregion
       
    }
}
