using System;
using System.Collections.Generic;
using System.Text;

namespace KJ128NModel
{
    public class Gstruct
    {
        /// <summary>
        /// 分站字体颜色
        /// </summary>
        private string g_stcolor;
        /// <summary>
        /// 人员字体颜色
        /// </summary>
        private string g_ptcolor;
        /// <summary>
        /// 人员字体背景
        /// </summary>
        private string g_pgcolor;
        /// <summary>
        /// 点颜色
        /// </summary>
        private string g_pcolor;
        /// <summary>
        /// 线颜色
        /// </summary>
        private string g_lcolor;
        /// <summary>
        /// 工作停顿时间标准
        /// </summary>
        private string g_stoptimevalue;
        /// <summary>
        /// 停顿时间
        /// </summary>
        private string g_stoptime;
        /// <summary>
        /// 间隔时间
        /// </summary>
        private string g_intervaltime;

        public string stcolor
        {
            get { return g_stcolor; }
            set { g_stcolor = value; }
        }

        public string ptcolor
        {
            get { return g_ptcolor; }
            set { g_ptcolor = value; }
        }

        public string pgcolor
        {
            get { return g_pgcolor; }
            set { g_pgcolor = value; }
        }

        public string pcolor
        {
            get { return g_pcolor; }
            set { g_pcolor = value; }
        }

        public string lcolor
        {
            get { return g_lcolor; }
            set { g_lcolor = value; }
        }

        public string stoptimevalue
        {
            get { return g_stoptimevalue; }
            set { g_stoptimevalue = value; }
        }

        public string stoptime
        {
            get { return g_stoptime; }
            set { g_stoptime = value; }
        }

        public string intervaltime
        {
            get { return g_intervaltime; }
            set { g_intervaltime = value; }
        }
    }
}
