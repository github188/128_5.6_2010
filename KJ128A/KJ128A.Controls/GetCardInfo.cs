using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Xml;

namespace KJ128A.Controls
{
    public class GetCardInfo
    {
        //private  string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        //private string connectionString = "server=.;database=KJ128N;uid=sa;pwd=sa;Connection Timeout=2";
        private string connectionString = "server=.;database=WiFi;uid=sa;pwd=128;Connection Timeout=2";
        public GetCardInfo()
        {
            connectionString = GetConfigValue("ConnectionString");
        }
        public DataSet ExecSql(string sql)
        {
            try
            {
                return Query(sql);
            }
            catch
            {
                return null;
            }
        }

        private DataSet Query(string SQLString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                DataSet ds = new DataSet();
                try
                {
                    connection.Open();
                    SqlDataAdapter command = new SqlDataAdapter(SQLString, connection);
                    command.Fill(ds, "ds");
                }
                catch (SqlException ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
                return ds;
            }
        }


        #region 【方法：获取标识卡所在分站为进的分站信息】
        /// <summary>
        /// 获取标识卡所在分站为进的分站信息
        /// </summary>
        /// <param name="iCards">标识卡信息</param>
        /// <returns></returns>
        public DataTable GetRTStnHead(string iCards)
        {

            return ExecSql("select SHI.StationAddress , SHI.StationHeadAddress ,RT.CodeSenderAddress from Station_Head_Info  as SHI join RT_InStationHeadInfo as RT on SHI.StationHeadID=RT.StationHeadID where  SHI.StationHeadTypeID=32 and  RT.InOutFlag=0 and  RT.CodeSenderAddress in ( " + iCards + " )").Tables[0];

        }
        #endregion

        #region qyz
        /// <summary>
        /// 根据传输分站寻找串口服务器
        /// </summary>
        /// <param name="iCard"></param>
        /// <returns></returns>
        public DataTable GetIPStaByCard(string iCard)
        {
            DataTable dt = new DataTable();
            string str = "select * from TcpIPConfig where IPID = (select IPAddressID from Station_Info where stationID = '" + iCard + "')";
            DataSet ds = ExecSql(str);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }


        /// <summary>
        /// 返回IP对应的传输分组组号
        /// </summary>
        /// <param name="ipaddress"></param>
        /// <returns></returns>
        public DataTable GetGroupID(string ipaddress)
        {
            string str = "select stationgroup from TcpIPConfig join Station_Info on TcpIPConfig.Ipid=Station_Info.ipaddressid where ipaddress='" + ipaddress + "'";
            DataTable dt = new DataTable();
            DataSet ds = ExecSql(str);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }
        #endregion

        #region【Czlt-1011-08-10 根据卡号查询当前进状态的分站信息】
        public string Czlt_GetRTStnHead(string iCards)
        {
            string strStaNum = "select SHI.StationAddress , SHI.StationHeadAddress ,RT.CodeSenderAddress from Station_Head_Info  as SHI join RT_InStationHeadInfo as RT on SHI.StationHeadID=RT.StationHeadID where  SHI.StationHeadTypeID=32 and  RT.InOutFlag=0 and  RT.CodeSenderAddress =" + iCards;
            DataSet ds = ExecSql(strStaNum);
            if (ds != null && ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    strStaNum = ds.Tables[0].Rows[0][0].ToString() + "," + ds.Tables[0].Rows[0][1].ToString();
                }
                else
                {
                    strStaNum = "";
                }

            }
            return strStaNum;
        }

        #endregion

        #region【Czlt-2011-08-19 查询所有的传输分站】
        /// <summary>
        /// Czlt-2011-08-19 查询所有的传输分站
        /// </summary>
        /// <returns></returns>
        public DataTable Czlt_GetRTAllSta()
        {
            DataTable dt = new DataTable();
            string strStaNum = "select distinct stationGroup,si.stationAddress  from dbo.Station_Info si left join dbo.Station_Head_Info shi on si.stationID = shi.StationAddress right join dbo.TcpIPConfig tcp on si.IpAddressID = tcp.IPid where stationHeadTypeID = 32";
            DataSet ds = ExecSql(strStaNum);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }
        #endregion


        #region 【Czlt-2012-3-27 通过存储过程查询查询】


        public DataTable Get_StationInfo(int flag)
        {
            try
            {
                SqlParameter[] sqlParmeters = { new SqlParameter("sign", SqlDbType.Int) };
                sqlParmeters[0].Value = flag;
                DataSet ds = GetDataSet("zjw_Select_Station", sqlParmeters);
                if (ds != null)
                    return ds.Tables[0];
                else
                    return new DataTable();
            }
            catch (Exception ex)
            {
                return new DataTable();
            }
        }

        /// <summary>
        /// 返回一个DS
        /// </summary>
        /// <param name="procName"></param>
        /// <param name="sqlParmeters"></param>
        /// <returns></returns>
        public DataSet GetDataSet(string procName, SqlParameter[] sqlParmeters)
        {
            //打开一个连接
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(connectionString))
                {
                    sqlConn.Open();
                    DataSet ds = new DataSet();
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                    sqlDataAdapter.SelectCommand = BuildSqlCommand(sqlConn, procName, sqlParmeters);
                    sqlDataAdapter.Fill(ds);
                    sqlDataAdapter = null;
                    sqlConn.Close();
                    return ds;
                }
            }
            catch (System.Data.SqlClient.SqlException sqlex)
            {
                //ErrorInfo(sqlex.Number);
                return null;
            }
            catch
            {
                return null;
            }
        }


        private SqlCommand BuildSqlCommand(SqlConnection sqlConn, string procName, SqlParameter[] sqlParmeters)
        {
            SqlCommand sqlComm = new SqlCommand(procName, sqlConn);
            sqlComm.CommandType = CommandType.StoredProcedure;
            if (sqlParmeters != null)
            {
                foreach (SqlParameter sqlParameter in sqlParmeters)
                {
                    sqlComm.Parameters.Add(sqlParameter);
                }
            }
            return sqlComm;
        }

        #endregion

        #region 【Czlt-2012-03-31 环网通讯时取消分站和交换机的关联,分站状态应为故障】
        /// <summary>
        /// Czlt-2012-03-31 环网通讯时取消分站和交换机的关联,分站状态应为故障
        /// </summary>
        public void Czlt_UpdateStaState()
        {
            string strSql = " update Station_Info set stationState=-1000 where IpAddressID is null or IpAddressID ='' ";
            ExecSql(strSql);
        }
        #endregion

        #region【Czlt-2013-05-14 修改数据库配置】
        /// <summary>
        /// czlt-2013-04-07 修改
        /// </summary>
        /// <param name="appKey"></param>
        /// <returns></returns>
        private string GetConfigValue(string appKey)
        {
            try
            {
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(System.Windows.Forms.Application.StartupPath + "\\KJ128NMainRun.exe.config");

                XmlNode xNode;
                XmlElement xElem;
                xNode = xDoc.SelectSingleNode("//appSettings");
                xElem = (XmlElement)xNode.SelectSingleNode("//add[@key='" + appKey + "']");
                if (xElem != null)
                    return xElem.GetAttribute("value");
                else
                    return "";
            }
            catch (Exception)
            {
                return "";
            }
        }
    
        #endregion

    }
}
