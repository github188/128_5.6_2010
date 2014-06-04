using System;
using System.Collections.Generic;
using System.Text;
using KJ128NDataBase;
using System.Data;

namespace KJ128NDBTable
{
    public class EnumBLL
    {

        #region [ 声明 ]

        private EnumInfoDAL eidal = new EnumInfoDAL();

        #endregion

        #region [ 方法: 获得EnumID return string ]

        public string getEnumID(string title, int funId)
        {
            return eidal.getEnumID(title, funId);
        }

        #endregion

        #region 根据FunID获取DataSet

        public DataSet GetEnumList(string funId)
        {
            return eidal.GetEnumList(funId);
        }

        #endregion
    }
}
