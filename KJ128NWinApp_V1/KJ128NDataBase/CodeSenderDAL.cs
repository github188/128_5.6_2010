using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace KJ128NDataBase
{
    public class CodeSenderDAL
    {
        private DBAcess dba = new DBAcess();
        private RealTimeDAL rtdal = new RealTimeDAL();

        #region [ ����: ���з�����״̬�޸�Ϊ���� ]

        /// <summary>
        /// ���з�����״̬�޸�Ϊ����
        /// </summary>
        /// <returns></returns>
        public bool InitAllCode()
        {
            string strSql = string.Format("update CodeSender_Info set CodeSenderStateID={0}",1);
            if (dba.ExistsSql(strSql) == -1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        #endregion

        #region [ ����: ���ط�������ϸ��Ϣ ]

        public DataSet getKJ128N_CodeSender_Info_Table(int pageIndex, int pageSize, string strWhere)
        {
            SqlParameter[] para = { new SqlParameter("@tblName",SqlDbType.VarChar,255),
                                    new SqlParameter("@keyField",SqlDbType.VarChar,255),
                                    new SqlParameter("@fieldList",SqlDbType.VarChar,2000),
                                    new SqlParameter("@orderField",SqlDbType.VarChar,255),
                                    new SqlParameter("@PageIndex",SqlDbType.Int),
                                    new SqlParameter("@PageSize",SqlDbType.Int),
                                    new SqlParameter("@strWhere",SqlDbType.VarChar,8000),
                                    new SqlParameter("@orderType",SqlDbType.Bit)
            };
            para[0].Value = "KJ128N_CodeSender_Info_Table";
            para[1].Value = "��������ַ";
            para[2].Value = "*";
            para[3].Value = "��������ַ";
            para[4].Value = pageIndex;
            para[5].Value = pageSize;
            if (strWhere == "")
                strWhere = "1=1";
            para[6].Value = strWhere;
            para[7].Value = 0;



            return dba.ExecuteSqlDataSet("GetPagingRecord", para);
        }

        #endregion

        //KJ128N_CodeSender_Set_Table
        #region [ ����: ���ط�����������Ϣ ]

        public DataSet getKJ128N_CodeSender_Set_Table(int pageIndex, int pageSize, string strWhere)
        {
            SqlParameter[] para = { new SqlParameter("@tblName",SqlDbType.VarChar,255),
                                    new SqlParameter("@keyField",SqlDbType.VarChar,255),
                                    new SqlParameter("@fieldList",SqlDbType.VarChar,2000),
                                    new SqlParameter("@orderField",SqlDbType.VarChar,255),
                                    new SqlParameter("@PageIndex",SqlDbType.Int),
                                    new SqlParameter("@PageSize",SqlDbType.Int),
                                    new SqlParameter("@strWhere",SqlDbType.VarChar,8000),
                                    new SqlParameter("@orderType",SqlDbType.Bit)
            };
            para[0].Value = "View_GetCodeSenderSetInfo_Table";
            para[1].Value = "��������ַ";
            para[2].Value = "�������,CsSet,CodeSenderID,��������ַ,����,�ƺ�,��������";
            para[3].Value = "��������ַ";
            para[4].Value = pageIndex;
            para[5].Value = pageSize;
            if (strWhere == "")
                strWhere = "1=1";
            para[6].Value = strWhere;
            para[7].Value = 0;

            return dba.ExecuteSqlDataSet("GetPagingRecord", para);
        }

        #endregion

        #region [ ����: ɾ�������� ]

        public int removeCodeSender(int id)
        {
            string sqlString = string.Format("Delete From CodeSender_Info Where CodeSenderID = {0}",id);
            return dba.ExecuteSql(sqlString);
        }

        #endregion

        #region [ ����: ɾ��������Ϣ ]

        public int removeCodeSenderSet(int id)
        {
            string sqlString = string.Format("Delete From CodeSender_Set Where CsSetID = {0}", id);
            // ��������
            string sql = string.Format("Update CodeSender_Info set IsCodeSenderUser=2 where CodeSenderID = (select CodeSenderID From CodeSender_Set where CsSetID = {0})", id);
            dba.ExecuteSql(sql);
            return dba.ExecuteSql(sqlString);
        }

        #endregion

        #region [ ����: �޸ķ����� ]

        // ����ָ����������Ϣ
        public DataSet getCodeSender(int id)
        {
            string sqlString = string.Format("Select * From CodeSender_Info Where CodeSenderID = {0}", id);
            return dba.GetDataSet(sqlString);
        }

        // �޸�
        public int updateCodeSender(int CodeSenderStateID,int id,string Remark)
        {
            string sqlString = string.Format("Update CodeSender_Info Set CodeSenderStateID = {0},Remark = '{1}' Where CodeSenderAddress = {2}", CodeSenderStateID, Remark, id);
            return dba.ExecuteSql(sqlString);
        }

        #endregion

        #region [ ����: ���÷����� ]
        // ���������� 0��Ա 1�豸
        public int addCodeSender_Set(int CodeSenderID, int UserID, int CsTypeID)
        {
            //string sqlString = string.Format("Insert Into CodeSender_Set(CodeSenderID,CodeSenderAddress,UserID,CsTypeID) "+
            //    "select {0},CodeSenderAddress,{1},{2} from CodeSender_Info where CodeSenderID={3}", CodeSenderID, UserID, CsTypeID, CodeSenderID);
            //string sql = string.Format("Update CodeSender_Info set IsCodeSenderUser=1 where CodeSenderID = {0}", CodeSenderID);
            //dba.ExecuteSql(sql);
            //return dba.ExecuteSql(sqlString);

            SqlParameter[] para = new SqlParameter[]{
                new SqlParameter("@CodeSenderID",SqlDbType.Int),
                new SqlParameter("@UserID",SqlDbType.Int),
                new SqlParameter("@CsTypeID",SqlDbType.Int)
            };

            para[0].Value = CodeSenderID;
            para[1].Value = UserID;
            para[2].Value = CsTypeID;

            return dba.ExecuteSql("InsertCodeSenderSet", para);
        }

        #endregion

        #region [ ����: ��÷�����״̬ö�� FunID=2 ]

        public DataSet getCodeSenderStateInfo()
        {
            return dba.GetDataSet("select EnumID,Title from EnumTable where FunID=2");
        }

        #endregion

        #region [ ����: ��ӷ�����������Ƿ���� ]

        // ��ӷ�����������Ƿ����
        public int getExistsCodeSenderAddress(int address, int alarmElectricity, int codeSenderStateID, int isCodeSenderUser, string remark)
        {
            
            string sqlString = string.Format("INSERT CodeSender_Info(CodeSenderAddress,AlarmElectricity,CodeSenderStateID,IsCodeSenderUser,Remark) " +
            "SELECT CodeSenderAddress,AlarmElectricity,CodeSenderStateID,IsCodeSenderUser,Remark " + " from (select {0} as CodeSenderAddress,{1} as AlarmElectricity,{2} as CodeSenderStateID"+
            ",{3} as IsCodeSenderUser,'{4}' as Remark,count(1) as ct FROM CodeSender_Info where CodeSenderAddress = {5}) as tmp where ct < 1"
            , address, alarmElectricity, codeSenderStateID, isCodeSenderUser, remark, address);
            return dba.ExecuteSql(sqlString);
        }

        // �������ʱ����Ѿ����ڵķ�վ��ַ
        public DataTable getExistsCodeSenderAddressList(string addressAll)
        {
            string sqlString = string.Format("SELECT col FROM Array_Split('{0}',',') where col in (select CodeSenderAddress from CodeSender_Info)", addressAll);
            DataSet ds = dba.GetDataSet(sqlString);
            if (ds != null)
                return dba.GetDataSet(sqlString).Tables[0];
            else
                return new DataTable();
        }

        #endregion

        #region [ ����: ������ӷ����� ]

        public int addCodeSenderInfo(string addressAll, int alarmElectricity, int codeSenderStateID, int isCodeSenderUser,string remark)
        {
            string sqlString = string.Format("insert into CodeSender_Info(CodeSenderAddress,AlarmElectricity,CodeSenderStateID,IsCodeSenderUser,Remark) " +
                "SELECT convert(int,col),{0},{1},{2},'{3}' FROM Array_Split('{4}',',') where col not in (select CodeSenderAddress from CodeSender_Info)",+
                0, codeSenderStateID, isCodeSenderUser,remark,addressAll);
            return dba.ExecuteSql(sqlString);
        }

        #endregion

        #region [ ����: �����Ա��Ϣ ]

        public DataSet getEmpInfo(string deptID)
        {
             // �õ�δ���õ���Ա
            string sqlString = string.Format("select EmpName,EmpID from (Select ei.EmpName,ei.EmpID,enc.DeptID From Emp_Info as ei "+
                    "inner Join Emp_NowCompany as enc on enc.EmpID = ei.EmpID Where ei.EmpID not in (Select UserID From CodeSender_Set Where CsTypeID=0)"+
                    ") as tmpTab where {0}" +
                " order by EmpName", deptID);
            return dba.GetDataSet(sqlString);
        }

        #endregion

        #region [ ����: ����豸��Ϣ ]

        public DataSet getEquInfo(string deptID)
        {
            // �õ�δ���õ��豸
            string sqlString = string.Format("select EquID,EquName from (Select EquID,EquName,DeptID From Equ_BaseInfo "+
                "Where EquID not in (Select UserID From CodeSender_Set Where CsTypeID=1)"+
                ") as tmpTab where {0} order by EquName", deptID);
            return dba.GetDataSet(sqlString);
        }

        #endregion

        #region [ ����: ��÷�������Ϣ ]

        public DataSet getCS()
        {
            string sqlString = string.Format("Select CodeSenderID,CodeSenderAddress,et.Title From CodeSender_Info as ci"+
            " left join EnumTable as et on et.EnumID = CodeSenderStateID and FunID=2"+
            " where CodeSenderAddress not in (Select CodeSenderAddress From CodeSender_Set)"+
            " order by CodeSenderAddress");

            return dba.GetDataSet(sqlString);
        }

        #endregion

        #region [ ����: �����Ա��Ϣ ]

        public DataSet getSmallEmpInfo(int empID)
        {
            string sqlString = string.Format("Select * From View_GetSmallEmpInfo where EmpID = {0}",empID);
            return dba.GetDataSet(sqlString);
        }

        #endregion

        #region [ ����: �����Ա��Ϣ ]

        public DataSet getSmallEquInfo(int equID)
        {
            string sqlString = string.Format("Select * From View_GetSmallEquInfo where EquID = {0}", equID);
            return dba.GetDataSet(sqlString);
        }

        #endregion

    }
}
