using System;
using System.Collections.Generic;
using System.Text;
using KJ128NDataBase;
using System.Data;

namespace KJ128NDBTable
{
    public class EnumBLL
    {

        #region [ ���� ]

        private EnumInfoDAL eidal = new EnumInfoDAL();

        #endregion

        #region [ ����: ���EnumID return string ]

        public string getEnumID(string title, int funId)
        {
            return eidal.getEnumID(title, funId);
        }

        #endregion

        #region ����FunID��ȡDataSet

        public DataSet GetEnumList(string funId)
        {
            return eidal.GetEnumList(funId);
        }

        #endregion
    }
}
