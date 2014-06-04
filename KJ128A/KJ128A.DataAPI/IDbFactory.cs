using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace KJ128A.DataAPI
{
    /// <summary>
    /// DBFactory �ӿ�
    /// </summary>
    public interface IDbFactory : ICollection
    {
        /// <summary> 
        /// ����Ĭ������ 
        /// </summary> 
        /// <returns>���ݿ�����</returns> 
        IDbConnection CreateConnection();

        /// <summary>
        /// �����������
        /// </summary>
        /// <returns></returns>
        IDbCommand CreateCommand();
    }
}
