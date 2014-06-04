using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
namespace KJ128NModel
{
    /// <summary>
    /// 存储过程参数结构
    /// </summary>
    [Serializable]
    public struct parameters
    {
        public string ParameterName;
        public SqlDbType  ParameterType;
        public object objValue;
        public int intLongth;
    }

    /// <summary>
    /// 序列化对象模型
    /// </summary>
    [Serializable]
    public class SerialModel
    {
        public string FuntionName;
        public parameters[] parameter;
        public string RestoryProcedureName;
        public string strSql;
        public string strReturnValue;
        public int ComandTime;
        public ArrayList Arraylist;
        public string strContent;
        public byte[] fs;
    }
}
