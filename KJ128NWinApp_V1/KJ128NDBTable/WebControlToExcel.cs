using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Xml;
using System.IO;
using System.Web.UI;

namespace KJ128NDBTable
{
    public class WebControlToExcel
    {
        #region ToExcel
        public void ToExcel(System.Web.UI.WebControls.DataGrid DG,string FileName)
        {
            HttpContext.Current.Response.Charset = "utf-8";
            HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-7");
            //Response.ContentType指定文件类型   可以为application/ms-excel   ||   application/ms-word   ||   application/ms-txt   ||   application/ms-html   ||   或其他浏览器可直接支持文档   
            HttpContext.Current.Response.ContentType = "application/ms-excel";
            HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment;filename=" + "" + FileName + ".xls");
            //关闭   ViewState   
            DG.Page.EnableViewState = false;
            //将信息写入字符串   
            System.IO.StringWriter tw = new System.IO.StringWriter();
            //在WEB窗体页上写出一系列连续的HTML特定字符和文本。   
            System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
            //此类提供ASP.NET服务器控件在将HTML内容呈现给客户端时所使用的格式化功能   
            //获取control的HTML
            DG.RenderControl(hw);
            //   把HTML写回浏览器   
            HttpContext.Current.Response.Write(tw.ToString());
            HttpContext.Current.Response.End();
        }        
        #endregion

    }

     
       


}
