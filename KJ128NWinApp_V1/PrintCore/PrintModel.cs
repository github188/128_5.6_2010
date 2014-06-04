using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace PrintCore
{
    public class PrintModel
    {
        private DataTable printtable;
        //数据表
        public DataTable Printtable
        {
            get { return printtable; }
            set { printtable = value; }
        }

        private List<string> columnname = new List<string>();
        /// <summary>
        /// 所有列的数据源列名
        /// </summary>
        public List<string> Columnname
        {
            get { return columnname; }
            set { columnname = value; }
        }


        private List<string> columntext = new List<string>();
        /// <summary>
        /// 所有列的别名
        /// </summary>
        public List<string> Columntext
        {
            get { return columntext; }
            set { columntext = value; }
        }


        //表格内容
        private List<string> columns = new List<string>();
        /// <summary>
        /// 选择的列名集合
        /// </summary>
        public List<string> Columns
        {
            get { return columns; }
            set { columns = value; }
        }
        private List<string> columnswidth = new List<string>();
        /// <summary>
        /// 选择的列宽集合
        /// </summary>
        public List<string> Columnswidth
        {
            get { return columnswidth; }
            set { columnswidth = value; }
        }


        private string printname;
        /// <summary>
        /// 打印表格名称
        /// </summary>
        public string Printname
        {
            get { return printname; }
            set { printname = value; }
        }
        /// <summary>
        /// 标题栏字体格式
        /// </summary>
        private string titlefontfamily;
        /// <summary>
        /// 标题栏字体名称
        /// </summary>
        public string Titlefontfamily
        {
            get { return titlefontfamily; }
            set { titlefontfamily = value; }
        }
        private float titlefontsize;
        /// <summary>
        /// 标题栏字号
        /// </summary>
        public float Titlefontsize
        {
            get { return titlefontsize; }
            set { titlefontsize = value; }
        }
        private string titlefontstyle;
        /// <summary>
        /// 标题栏对齐方式
        /// </summary>
        public string Titlefontstyle
        {
            get { return titlefontstyle; }
            set { titlefontstyle = value; }
        }


        //副标题字体格式
        private string subfontfamily;
        /// <summary>
        /// 副标题字体名称
        /// </summary>
        public string Subfontfamily
        {
            get { return subfontfamily; }
            set { subfontfamily = value; }
        }
        private float subfontsize;
        /// <summary>
        /// 副标题字号
        /// </summary>
        public float Subfontsize
        {
            get { return subfontsize; }
            set { subfontsize = value; }
        }
        private string subfontstyle;
        /// <summary>
        /// 副标题对齐方式
        /// </summary>
        public string Subfontstyle
        {
            get { return subfontstyle; }
            set { subfontstyle = value; }
        }

        //内容字体格式
        private string contentfontfamily;
        /// <summary>
        /// 表格字体名称
        /// </summary>
        public string Contentfontfamily
        {
            get { return contentfontfamily; }
            set { contentfontfamily = value; }
        }
        private float contentfontsize;
        /// <summary>
        /// 表格字号
        /// </summary>
        public float Contentfontsize
        {
            get { return contentfontsize; }
            set { contentfontsize = value; }
        }
        private string contentfontstyle;
        /// <summary>
        /// 表格字体对齐方式
        /// </summary>
        public string Contentfontstyle
        {
            get { return contentfontstyle; }
            set { contentfontstyle = value; }
        }

        //签名栏字体格式
        private string signfontfamily;
        /// <summary>
        /// 签名栏字体名称
        /// </summary>
        public string Signfontfamily
        {
            get { return signfontfamily; }
            set { signfontfamily = value; }
        }
        private float signfontsize;
        /// <summary>
        /// 签名栏字号
        /// </summary>
        public float Signfontsize
        {
            get { return signfontsize; }
            set { signfontsize = value; }
        }
        private string signfontstyle;
        /// <summary>
        /// 签名栏对齐方式
        /// </summary>
        public string Signfontstyle
        {
            get { return signfontstyle; }
            set { signfontstyle = value; }
        }

        //纸张大小
        private string paperwidth;
        /// <summary>
        /// 纸张宽度cm
        /// </summary>
        public string Paperwidth
        {
            get { return paperwidth; }
            set { paperwidth = value; }
        }
        private string paperheight;
        /// <summary>
        /// 纸张高度cm
        /// </summary>
        public string Paperheight
        {
            get { return paperheight; }
            set { paperheight = value; }
        }


        //纸张边距
        private string papertop;
        /// <summary>
        /// 纸张上边距cm
        /// </summary>
        public string Papertop
        {
            get { return papertop; }
            set { papertop = value; }
        }
        private string paperbottom;
        /// <summary>
        /// 纸张下边距cm
        /// </summary>
        public string Paperbottom
        {
            get { return paperbottom; }
            set { paperbottom = value; }
        }
        private string paperleft;
        /// <summary>
        /// 纸张左边距cm
        /// </summary>
        public string Paperleft
        {
            get { return paperleft; }
            set { paperleft = value; }
        }
        private string paperright;
        /// <summary>
        /// 纸张右边距cm
        /// </summary>
        public string Paperright
        {
            get { return paperright; }
            set { paperright = value; }
        }


        //签名栏
        private string signcontent;
        /// <summary>
        /// 签名栏内容（用,分隔）
        /// </summary>
        public string Signcontent
        {
            get { return signcontent; }
            set { signcontent = value; }
        }
       


        private string tjtime;
        /// <summary>
        /// 统计时间
        /// </summary>
        public string Tjtime
        {
            get { return tjtime; }
            set { tjtime = value; }
        }

    }
}
