using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace KJ128NDataBase
{
    public class ConDirectionalManageDAL
    {

        #region [ 声明 ]

        private DBAcess dbacc = new DBAcess();

        private string strSql = string.Empty;

        #endregion


        #region [ 方法: 查询方向性配置信息 ]

        public DataSet N_SearchDirectionalManage(string txtDetection, string strWhere)
        {
            bool blIsFirst = false;
            strSql = " Select " +
                        " DetectionInfo  as 标识, " +
                        " dbo.FunTrendInfo(DetectionInfo) as 位置, " +
                        " Directional as 方向性描述 " +
                     " From " +
                        " CodeSender_Directional ";
            if (!(txtDetection.Equals("") | txtDetection.Equals(null)))
            {
                strSql += " Where DetectionInfo like '%" + txtDetection + "%'";
                blIsFirst = true;
            }
            if (!(strWhere.Equals("") | strWhere.Equals(null)))
            {
                if (blIsFirst)
                {
                    strSql += " And Directional like '%" + strWhere + "%'";
                }
                else
                {
                    strSql += " Where Directional like '%" + strWhere + "%'";
                }
            }

            return dbacc.GetDataSet(strSql);
        }

        #endregion
    }
}
