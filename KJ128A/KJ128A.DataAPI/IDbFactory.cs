using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace KJ128A.DataAPI
{
    /// <summary>
    /// DBFactory 接口
    /// </summary>
    public interface IDbFactory : ICollection
    {
        /// <summary> 
        /// 建立默认连接 
        /// </summary> 
        /// <returns>数据库连接</returns> 
        IDbConnection CreateConnection();

        /// <summary>
        /// 建立命令对象
        /// </summary>
        /// <returns></returns>
        IDbCommand CreateCommand();
    }
}
