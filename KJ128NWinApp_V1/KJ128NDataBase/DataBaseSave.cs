using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace KJ128NDataBase
{
    /// <summary>
    /// 枚举数据存储模式
    /// </summary>
    public enum DataBaseSaveMode
    {
       /// <summary>
       /// 写SQL数据库模式
       /// </summary>
        WriteSqlDataBase,
        /// <summary>
        /// 写XML数据文件
        /// </summary>
        WriteXmlDataFile
    }
    public class DataBaseSave
    {
        
        #region 私有变量
        private static DataBaseSaveMode m_SaveMode = DataBaseSaveMode.WriteSqlDataBase;
        private DBAcess m_DBAcess = new DBAcess();
        #endregion
        #region 构造函数
        /// <summary>
        /// 数据存储
        /// </summary>
        /// <param name="procName"></param>
        /// <param name="sqlParameters"></param>
        public DataBaseSave()
        {
        }
        #endregion
        #region 方法
        public IDBAcess GetDBAcess()
        {
            switch (m_SaveMode)
            {
                case DataBaseSaveMode.WriteSqlDataBase:
                    {
                        return new DBAcess();
                    }
                case DataBaseSaveMode.WriteXmlDataFile:
                    {
                        return new DBAcess();
                    }
            }
            return null;
        }
        #endregion

        #region 属性
        /// <summary>
        /// 创建一个DBAcess对象
        /// </summary>
        public DBAcess CreateDBAcess
        {
            get
            {
                return m_DBAcess;
            }
            set
            {
                m_DBAcess = value;
            }
        }
        /// <summary>
        /// 数据存储模式
        /// </summary>
        public DataBaseSaveMode SaveMode
        {
            get
            {
                return m_SaveMode;
            }
            set
            {
                m_SaveMode = value;
            }
        }
        #endregion
    }
}
