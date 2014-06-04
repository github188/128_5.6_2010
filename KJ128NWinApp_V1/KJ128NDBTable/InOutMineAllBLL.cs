using System;
using System.Collections.Generic;
using System.Text;
using KJ128NDataBase;
using System.Data;

namespace KJ128NDBTable
{
    /// <summary>
    /// 进出井所有信息统计BLL
    /// </summary>
    public class InOutMineAllBLL
    {
        private InOutMineAllDAL dal = new InOutMineAllDAL();

        /// <summary>
        /// 查询进出井所有信息
        /// </summary>
        ///<param name="pageIndex">分页索引</param>
        ///<param name="pageSize">每页记录条数</param>
        ///<param name="where">查询条件</param>
        /// <returns>数据集</returns>
        public DataSet SelectInOutMineAllInfo(int pageIndex, int pageSize, string where)
        {
            if (dal == null)
                dal = new InOutMineAllDAL();

            return dal.SelectInOutMineAllInfo(pageIndex, pageSize, where);
        }
    }
}
