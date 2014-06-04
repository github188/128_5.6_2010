using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections.ObjectModel;
using System.Windows.Forms;
using KJ128NInterfaceShow;

namespace PrintCore
{
    /// <summary>
    /// 字段和报表列的映射类
    /// </summary>
    public class FieldMappingColumn
    {
        /// <summary>
        /// 数据源字段
        /// </summary>
        private string filed;
        /// <summary>
        /// 数据源字段
        /// </summary>
        public string Filed
        {
            get { return filed; }
            set { filed = value; }
        }

        /// <summary>
        /// 报表上显示的列名
        /// </summary>
        private string columnName;
        /// <summary>
        /// 报表上显示的列名
        /// </summary>
        public string ColumnName
        {
            get { return columnName; }
            set { columnName = value; }
        }

        /// <summary>
        /// 在报表中列长度
        /// </summary>
        private string columnWidth;
        /// <summary>
        /// 在报表中列长度
        /// </summary>
        public string ColumnWidth
        {
            get { return columnWidth; }
            set { columnWidth = value; }
        }

        /// <summary>
        /// 表示这列是否可见
        /// </summary>
        private bool visible = true;
        /// <summary>
        /// 表示这列是否可见
        /// </summary>
        public bool Visible 
        {
            get { return visible; }
            set { visible = value; }
        }
    }

    /// <summary>
    /// 打印组件接口
    /// </summary>
    public interface IPrintComponent
    {
        #region [临时]

        /// <summary>
        /// 判断报表模板是否加载过
        /// </summary>
        //bool IsTemplateFileLoaded { get;}

        /// <summary>
        /// 加载报表模板
        /// </summary>
        /// <param name="path">报表模板路径</param>
        //void LoadTemplateFile(string path);

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
        //void CallPrintForm(DataTable dt, Collection<FieldMappingColumn> mappings, params object[] printParams);

        #endregion

        #region [Common parts]

        /// <summary>
        /// 调出打印窗体
        /// </summary>
        /// <param name="dgv">要打印的DataGridView控件</param>
        /// <param name="title">打印标题</param>
        /// <param name="sum">总数标题</param>
        //void CallPrintForm( DataGridViewKJ128 dgv, string title,string sum);


        /// <summary>
        /// 调出打印窗体
        /// </summary>
        /// <param name="dgv">要打印的DataGridView控件</param>
        /// <param name="title">打印标题</param>
        /// <param name="sum">总数标题</param>
        /// <param name="isAutoPrint">是否自动打印</param>
        //void CallPrintForm(DataGridViewKJ128 dgv, string title, string sum, bool isAutoPrint);

        /// <summary>
        /// 调出打印窗体
        /// </summary>
        /// <param name="dgv">要打印的DataGridView控件</param>
        /// <param name="title">打印标题</param>
        /// <param name="sum">总数标题</param>
        void CallPrintForm(DataGridView dgv, string title, string sum);

        /// <summary>
        /// 调出打印窗体
        /// </summary>
        /// <param name="dgv">要打印的DataGridView控件</param>
        /// <param name="title">打印标题</param>
        /// <param name="sum">总数标题</param>
        /// <param name="isAutoPrint">是否自动打印</param>
        void CallPrintForm(DataGridView dgv, string title, string sum, bool isAutoPrint);



        #endregion
    }
}
