using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using KJ128NDataBase;
using KJ128WindowsLibrary;
using System.Windows.Forms;
using System.Drawing;
using KJ128NModel;

namespace KJ128NDBTable
{
    public class AddEmpBLL
    {
        #region [ ���� ]

        private AddEmpDAL aedal = new AddEmpDAL();
        private EnumInfoDAL eidal = new EnumInfoDAL();
        private DeptDAL ddal = new DeptDAL();

        DataSet ds;
        private string strSql = string.Empty;

        Font font_labelFont = new Font
               ("����", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        Color color_ForeColor = Color.FromArgb(32, 77, 137);
        Color color_BackColor = Color.FromArgb(231, 235, 247);

        #endregion

        #region [2008-6-23�޸ĵ����Ա����Ϣ�ķ���,ͨ��EmpModel��������ִ��һ���洢����]

        /// <summary>
        /// ����Ա����Ϣ(ȫ��10�ű���Ϣ)
        /// </summary>
        /// <param name="empModel">Ա����ʵ��</param>
        /// <returns>����ִ��Ӱ������������0��ִ�гɹ�</returns>
        public int InsertEmpInfo(EmpModel empModel)
        {
            //if (aedal == null)
            //    aedal = new AddEmpDAL();

            //return aedal.InsertEmpInfo(empModel);
            return 0;
        }

        /// <summary>
        /// �޸�Ա����Ϣ(ȫ��10�ű���Ϣ)
        /// </summary>
        /// <param name="empModel">Ա����ʵ��</param>
        /// <returns>����ִ��Ӱ������������0��ִ�гɹ�</returns>
        public int UpdateEmpInfo(EmpModel empModel)
        {
            //if (aedal == null)
            //    aedal = new AddEmpDAL();

            //return aedal.UpdateEmpInfo(empModel);
            return 0;
        }

        #endregion

        #region �� ����: ��� Ա����Ϣ ��

        public int SaveEmpInfo()
        {

            return 0;
        }

        #endregion

        #region [ ����: ��� Ա����Ϣ ]
        /// <summary>
        /// �洢Ա��������Ϣ
        /// </summary>
        /// <param name="empName">Ա������</param>
        /// <param name="empNO">Ա������</param>
        /// <param name="sex">Ա���Ա�</param>
        /// <param name="remark">��ע</param>
        /// <returns>����Ӱ������(int)</returns>
        public int SaveEmployeeBaseInfoData(string empName, string empNO, bool sex, string remark)
        {
            return aedal.SaveEmployeeBaseInfoData(empName, empNO, sex, remark);
        }
        #endregion

        #region [ ����: �洢Ա����Ϣ��ϸ ]
        /// <summary>
        /// ���Ա����Ϣ��ϸ
        /// </summary>
        /// <param name="EmpNO">Ա��NO</param>
        /// <param name="Nation">����</param>
        /// <param name="WedlockID">����״��</param>
        /// <param name="ClanID">������ò</param>
        /// <param name="NativePlace">����</param>
        /// <param name="CensusRegister">����</param>
        /// <param name="SchoolRecordID">ѧ��</param>
        /// <param name="GraduateFrom">��ҵԺУ</param>
        /// <param name="Specialty">רҵ</param>
        /// <param name="OfficialDesignation">ְ��</param>
        /// <param name="Remark">��ע</param>
        /// <param name="BirthDay">����</param>
        /// <param name="IDcard">���֤</param>
        /// <returns>����Ӱ������</returns>
        public int SaveEmployeeDetaiData(string EmpNO, String Nation, int WedlockID, int ClanID, String NativePlace, String CensusRegister, int SchoolRecordID, String GraduateFrom, String Specialty, String OfficialDesignation, String Remark, String BirthDay, String IDcard)
        {
            return aedal.SaveEmployeeDetaiData(EmpNO, Nation, WedlockID, ClanID, NativePlace, CensusRegister, SchoolRecordID, GraduateFrom, Specialty, OfficialDesignation, Remark, BirthDay, IDcard);
        }
        #endregion

        #region [ ����: �洢Ա����ϵ��ʽ ]

        /// <summary>
        /// ���Ա����ϵ��ʽ
        /// </summary>
        /// <param name="EmpNO">Ա��NO</param>
        /// <param name="EmpTel1">�ֻ�����</param>
        /// <param name="EmpTel2">С��ͨ����</param>
        /// <param name="EmpTel3">���õ绰����</param>
        /// <param name="EmpQQ">QQ����</param>
        /// <param name="EmpMsn">Msn����</param>
        /// <param name="HomePage">������ҳ</param>
        /// <param name="EmpEmail">��������(��)</param>
        /// <param name="EmpEmailBackup">��������(����)</param>
        /// <param name="Remark">��ע</param>
        /// <returns>����Ӱ������</returns>
        public int SaveEmployeeSearchData(string EmpNO, String EmpTel1, String EmpTel2, String EmpTel3, String EmpQQ, String EmpMsn, String HomePage, String EmpEmail, String EmpEmailBackup, String Remark)
        {
            return aedal.SaveEmployeeSearchData(EmpNO, EmpTel1, EmpTel2, EmpTel3, EmpQQ, EmpMsn, HomePage, EmpEmail, EmpEmailBackup, Remark);
        }
        #endregion

        #region [ ����: �洢Ա����ͥ��Ϣ ]

        /// <summary>
        /// ���Ա����ͥ��Ϣ
        /// </summary>
        /// <param name="EmpNO">Ա��NO</param>
        /// <param name="HomeTel1">��ͥ�绰1</param>
        /// <param name="HomeTel2">��ͥ�绰2</param>
        /// <param name="HomeAddress">��ͥסַ</param>
        /// <param name="Postalcode">��������</param>
        /// <param name="Remark">��ע</param>
        /// <returns>����Ӱ������</returns>
        public int SaveEmployeeHomeData(string EmpNO, String HomeTel1, String HomeTel2, String HomeAddress, String Postalcode, String Remark)
        {
            return aedal.SaveEmployeeHomeData(EmpNO, HomeTel1, HomeTel2, HomeAddress, Postalcode, Remark);
        }
        #endregion

        #region [ ����: �洢Ա������˾��� ]

        /// <summary>
        /// ���Ա������˾���
        /// </summary>
        /// <param name="EmpNO">Ա��NO</param>
        /// <param name="ProbationDate">��������</param>
        /// <param name="OfficiallyDate">ת������</param>
        /// <param name="ContractExpDate">��ͬ��Ч��</param>
        /// <param name="ContractExpAppendDate">��ǩ��Ч��</param>
        /// <param name="IsGearShift">�Ƿ��ѵ���</param>
        /// <param name="HireTypeID">Ƹ����ʽ</param>
        /// <param name="Archives">�������ڵ�</param>
        /// <param name="DimissionTime">��ְʱ��</param>
        /// <param name="Remark">��ע</param>
        /// <returns>����Ӱ������</returns>
        public int SaveEmployeeComeCompanyInfoData(string EmpNO, String ProbationDate, String OfficiallyDate, String ContractExpDate, String ContractExpAppendDate, Byte IsGearShift, Int32 HireTypeID, String Archives, String DimissionTime, String Remark)
        {
            return aedal.SaveEmployeeComeCompanyInfoData(EmpNO, ProbationDate, OfficiallyDate, ContractExpDate, ContractExpAppendDate, IsGearShift, HireTypeID, Archives, DimissionTime, Remark);
        }
        #endregion

        #region [ ����: �洢Ա������״�� ]

        /// <summary>
        /// ���Ա������״��
        /// </summary>
        /// <param name="EmpID">Ա��ID</param>
        /// <param name="Height">���</param>
        /// <param name="Weight">����</param>
        /// <param name="StateOfHealth">����״��</param>
        /// <returns>����Ӱ������</returns>
        public int SaveHealthData(string EmpNO, string Height, string Weight, string StateOfHealth)
        {
            int x, y;
            if (Height.CompareTo("") == 0)
            {
                x = 0;
            }
            else
            {
                x = Convert.ToInt32(Height);
            }
            if (Weight.CompareTo("") == 0)
            {
                y = 0;
            }
            else
            {
                y = Convert.ToInt32(Weight);
            }
            return aedal.SaveHealthData(EmpNO, x, y, StateOfHealth);
        }
        #endregion

        #region [ ����: �洢Ա���ڵ�λ��� ]

        /// <summary>
        /// ���Ա���ڵ�λ���
        /// </summary>
        /// <param name="EmpID">Ա��ID</param>
        /// <param name="DeptID">����ID</param>
        /// <param name="DutyID">ְ��ID</param>
        /// <param name="Remark">��ע</param>
        /// <returns>����Ӱ������</returns>
        public int SaveEmployeeNowCompanyData(string EmpNO, int DeptID, int DutyID, int MaxHour,int MaxMinute,int MaxSecond,int MinHour,int MinMinute,int MinSecond,int SelectMode, string Remark,string strClassGroup,string strWorkPlace)
        {
            int MaxTimeSec, MinTimeSec;
            MaxTimeSec = MaxHour * 3600 + MaxMinute * 60 + MaxSecond;
            MinTimeSec = MinHour * 3600 + MinMinute * 60 + MinSecond;
            return aedal.SaveEmployeeNowCompanyData(EmpNO, DeptID, DutyID, MaxTimeSec, MinTimeSec, SelectMode, Remark,strClassGroup,strWorkPlace);
        }
        #endregion

        #region [ ����: ����Ա��������Ϣ ]

        public int SaveWorkTypeData(string EmpNO, int WorkTypeID, int IsMostly, int IsEnable)
        {
            return aedal.SaveWorkTypeData(EmpNO, WorkTypeID, IsMostly, IsEnable);
        }
        #endregion

        #region [ ����: ��� ��Ƭ ]

        public int SaveEmpPhoto(string EmpNO,byte[] Photo, string Remark)
        {
            return aedal.SaveEmpPhoto(EmpNO,Photo, Remark);
        }
        #endregion

        #region [ ����: �޸� ��Ƭ ]

        public int UpDateEmpPhoto(int PhotoID ,string EmpNO, byte[] Photo, string Remark)
        {
            return aedal.UpDateEmpPhoto(PhotoID, EmpNO, Photo, Remark);
        }
        #endregion

        #region [ ����: ɾ�� ��Ƭ ]

        public int DeleteEmpPhoto(int EmpID)
        {
            return aedal.DeleteEmpPhoto(EmpID);
        }
                #endregion

        #region [ ����: ��ȡPhotoID ]

        public int GetPhotoID(int EmpID)
        {
            return aedal.GetPhotoID(EmpID);
        }
        #endregion

        #region  [ ����: ����PhotoID������DataTable ]

        public DataTable GetPhotoTab(int PhotoID)
        {
            return aedal.GetPhotoTab(PhotoID);
        }

        #endregion

        #region [ ����: �޸�Ա��������Ϣ ]

        public int UpDateEmpInfo(int EmpID, string EmpNO, string EmpName, int Sex, string Remark)
        {
            return aedal.UpDateEmpInfo(EmpID, EmpNO, EmpName, Sex, Remark);
        }
        #endregion 

        #region [ ����: �޸� Ա��������Ϣ ]
        public int UpDateEmpWorkType(int EmpWorkTypeID, int WorkTypeID, byte IsMostly, byte IsEnable)
        {
            return aedal.UpDateEmpWorkType(EmpWorkTypeID, WorkTypeID, IsMostly, IsEnable);
        }
        #endregion

        #region [ ����: ɾ�� ������Ϣ ]
        public int DeleteEmpWorkType(int EmpWorkTypeID)
        {
            return aedal.DeleteEmpWorkType(EmpWorkTypeID);
        }
        #endregion

        #region [ ����: ��ȡԱ��ID ]
        /// <summary>
        /// ��ȡԱ��ID
        /// </summary>
        /// <param name="EmpNo">Ա�����</param>
        /// <returns>����Ա��ID</returns>
        public int GetEmpID(string EmpNo)
        {
            string strsql = string.Format("select EmpID from Emp_Info where EmpNo='{0}'", EmpNo);
            return ddal.GetID(strsql);
        }
        #endregion

        #region [ ����: ��ȡƸ����ʽ��Table ]

        /// <summary>
        /// ��ȡƸ����ʽ��Table
        /// </summary>
        /// <returns>����Ƹ����ʽ��Table</returns>
        public DataTable GetEmpHireTypeTab()
        {
            return eidal.getEnumInfo(43);
        }

        #endregion

        #region [ ����: ��ȡѧ��Table ]

        /// <summary>
        /// ��ȡѧ��Table
        /// </summary>
        /// <returns>����ѧ��Table</returns>
        public DataTable GetEmpSchoolRecordTab()
        {
            return eidal.getEnumInfo(42);
        }
        #endregion

        #region [ ����: ��ȡ������òTable ]

        /// <summary>
        /// ��ȡ������òTable
        /// </summary>
        /// <returns>����������òTable</returns>
        public DataTable GetEmpClanTab()
        {
            return eidal.getEnumInfo(41);
        }
        #endregion

        #region [ ����: ��ȡ����״��Table ]

        /// <summary>
        /// ��ȡ����״��Table
        /// </summary>
        /// <returns>���ػ���״��Table</returns>
        public DataTable GetEmpWedlockTab()
        {
            return eidal.getEnumInfo(40);
        }
        #endregion

        #region [ ����: ��ȡ�Ա�Table ]

        /// <summary>
        /// ��ȡ�Ա�Table
        /// </summary>
        /// <returns>�����Ա�Table</returns>
        public DataTable GetEmpSexTab()
        {
            return eidal.getEnumInfo(44);
        }
        #endregion

        #region [ ����: ��ȡ����ģʽTable ]
        /// <summary>
        /// ��ȡ����ģʽTable
        /// </summary>
        /// <returns>��������ģʽTable</returns>
        public DataTable GetSelectmodeTab()
        {
            return eidal.getEnumInfo(45);
        }
        #endregion

        #region [ ����: ��ȡ����Table ]

        /// <summary>
        /// ��ȡ������ϢTable
        /// </summary>
        /// <returns>���ز���Table</returns>
        public DataTable GetDeparmentTab()
        {
            return aedal.GetDeparmentTab();
        }
        #endregion

        #region [ ����: ��ȡְ��Table ]
        /// <summary>
        /// ��ȡְ��Table
        /// </summary>
        /// <returns>����ְ��Table</returns>
        public DataTable GetEmpDutyTab()
        {
            return aedal.GetEmpDutyTab();
        }
        #endregion

        #region [ ����: �󶨹��� ]

        /// <summary>
        /// �󶨹���
        /// </summary>
        /// <returns>����ComboBox</returns>
        public ComboBox GetWorkTypeCmb(ComboBox cmb)
        {
            DataSet ds = ddal.getWorkTypeInfo();
            if (ds.Tables != null && ds.Tables.Count > 0)
            {
                cmb.Items.Clear();
                DataRow dr = ds.Tables[0].NewRow();
                dr[0] = 0;
                dr[1] = "��";
                ds.Tables[0].Rows.InsertAt(dr, 0);
                cmb.DataSource = ds.Tables[0];
                cmb.DisplayMember = "WtName";
                cmb.ValueMember = "WorkTypeID";
            }
            return cmb;
        }
        #endregion

        #region [ ����: ����SQL��䣬������Ա��Ϣ(DataTable) ]

        /// <summary>
        /// ����SQL��䣬������Ա��Ϣ(DataTable)
        /// </summary>
        /// <param name="sql">SQL���</param>
        /// <returns>������Ա��Ϣ(DataTable)</returns>
        public DataTable GetDataTableEmp(string sql)
        {
            return aedal.GetDataTableEmp(sql);
        }
        #endregion

        #region [ ����: ��ȡԱ��������ϢTable ]

        /// <summary>
        /// ��ȡԱ��������Ϣ(Table)
        /// </summary>
        /// <param name="EmpID">Ա��ID</param>
        /// <returns>����Ա��������Ϣ(Table)</returns>
        public DataTable GetEmpBaseInfoTab(int EmpID)
        {
            string strsql = string.Format("select * from Emp_Info where EmpID={0}", EmpID);
            return ddal.GetTable(strsql);
        }
        #endregion

        #region [ ����: ��ȡԱ����Ϣ��ϸTable ]

        /// <summary>
        /// ��ȡԱ����Ϣ��ϸ(Table)
        /// </summary>
        /// <param name="EmpID">Ա��ID</param>
        /// <returns>����Ա����Ϣ��ϸ(Table)</returns>
        public DataTable GetEmpDetailTab(int EmpID)
        {
            string strsql = string.Format("select * from Emp_Detail where EmpID={0}", EmpID);
            return ddal.GetTable(strsql);
        }
        #endregion

        #region [ ����: ��ȡԱ����ϵ��ʽTable ]

        /// <summary>
        /// ��ȡԱ����ϵ��ʽ(Table)
        /// </summary>
        /// <param name="EmpID">Ա��ID</param>
        /// <returns>����Ա����ϵ��ʽ(Table)</returns>
        public DataTable GetEmpSearchTab(int EmpID)
        {
            string strsql = string.Format("select * from Emp_Search where EmpID={0}", EmpID);
            return ddal.GetTable(strsql);
        }
        #endregion

        #region [ ����: ��ȡԱ����ͥ��ϢTable ]

        /// <summary>
        /// ��ȡԱ����ͥ��Ϣ(Table)
        /// </summary>
        /// <param name="EmpID">Ա��ID</param>
        /// <returns>����Ա����ͥ��Ϣ(Table)</returns>
        public DataTable GetEmpHomeTab(int EmpID)
        {
            string strsql = string.Format("select * from Emp_Home where EmpID={0}", EmpID);
            return ddal.GetTable(strsql);
        }
        #endregion

        #region [ ����: ��ȡԱ������״��Table ]

        /// <summary>
        /// ��ȡԱ������״��(Table)
        /// </summary>
        /// <param name="EmpID">Ա��ID</param>
        /// <returns>����Ա������״��(Table)</returns>
        public DataTable GetEmpHealthTab(int EmpID)
        {
            string strsql = string.Format("select * from Emp_Health where EmpID={0}", EmpID);
            return ddal.GetTable(strsql);
        }
        #endregion

        #region [ ����: ��ȡԱ������˾���Table ]

        /// <summary>
        /// ��ȡԱ������˾���(Table)
        /// </summary>
        /// <param name="EmpID">Ա��ID</param>
        /// <returns>����Ա������˾���(Table)</returns>
        public DataTable GetEmpInCompanyTab(int EmpID)
        {
            string strsql = string.Format("select * from Emp_InCompany where EmpID={0}", EmpID);
            return ddal.GetTable(strsql);
        }
                #endregion

        #region [ ����: ��ȡԱ���ڹ�˾���Table ]

        /// <summary>
        /// ��ȡԱ���ڹ�˾���(Table)
        /// </summary>
        /// <param name="EmpID">Ա��ID</param>
        /// <returns>����Ա���ڹ�˾���(Table)</returns>
        public DataTable GetEmpNowCompanyTab(int EmpID)
        {
            string strsql = string.Format("select * from Emp_NowCompany where EmpID={0}", EmpID);
            return ddal.GetTable(strsql);
        }
        #endregion

        #region [ ����: ��ȡ��������Table ]

        public DataTable GetDeptSysSetTab(int DeptID)
        {
            string strsql = string.Format("select * from Dept_SysSet where DeptID={0}", DeptID);
            return ddal.GetTable(strsql);
        }
        #endregion

        #region [ ����: ��ȡ��������Table ]

        public DataTable GetWorkTypeSysSetTab(int WorkTypeID)
        {
            string strsql = string.Format("select * from WorkType_SysSet where WorkTypeID={0}", WorkTypeID);
            return ddal.GetTable(strsql);
        }
        #endregion

        #region [ ����: ��ȡԱ����������Table ]

        /// <summary>
        /// ��ȡԱ����������(Table)
        /// </summary>
        /// <param name="EmpID">Ա��ID</param>
        /// <returns>����Ա����������(Table)</returns>
        public DataTable GetEmpWorkTypeTab(int EmpID)
        {
            string strsql = string.Format("select * from Emp_WorkType where EmpID={0}", EmpID);
            return ddal.GetTable(strsql);
        }
         #endregion

        #region [ ����: ���ݲ�ѯ��ʽ�õ���ѯ���� ]

        /// <summary>
        /// ���ݲ�ѯ��ʽ�õ���ѯ����
        /// </summary>
        /// <param name="strTest"></param>
        /// <param name="selectFun">1 ��ȷ</param>
        /// <returns></returns>
        public string SelectWhere(string[,] strTest, int selectFun)
        {
            string strNewSql = string.Empty;
            bool blnFirst = true;
            bool isWorkType = false;
            for (int i = 0; i < strTest.GetUpperBound(0) + 1; i++)
            {
                if (strTest[i, 2].Trim() != string.Empty)
                {
                    if (strTest[i, 3].Trim() == "string")
                    {
                        if (strTest[i, 0].Trim() == "��������")
                        {
                            isWorkType = true;
                        }
                        else
                        {
                            isWorkType = false;
                        }
                        if (selectFun == 1)
                        {
                            //��ȷ
                            strTest[i, 2] = "'" + strTest[i, 2].Trim() + "'";
                        }
                        else
                        {
                            //ģ��
                            strTest[i, 2] = "'%" + strTest[i, 2].Trim() + "%'";
                            strTest[i, 1] = "like";
                        }
                    }

                    if (strTest[i, 3].Trim() == "datetime")
                    {
                        strTest[i, 2] = "'" + strTest[i, 2].Trim() + "'";
                    }


                    if (blnFirst)
                    {
                        if (isWorkType)
                        {
                            strNewSql ="("+ strTest[i, 0].Trim() + " " + strTest[i, 1].Trim() + " " + strTest[i, 2].Trim() + ") and IsEnable=1";
                            blnFirst = false;
                        }
                        else
                        {
                            strNewSql = "(" + strTest[i, 0].Trim() + " " + strTest[i, 1].Trim() + " " + strTest[i, 2].Trim() + ")";
                            blnFirst = false;
                        }
                    }
                    else if (isWorkType)
                    {
                        strNewSql += "and (" + strTest[i, 0].Trim() + " " + strTest[i, 1].Trim() + " " + strTest[i, 2].Trim() + ") and IsEnable=1";
                    }
                    else
                    {
                        strNewSql += " and (" + strTest[i, 0].Trim() + " " + strTest[i, 1].Trim() + " " + strTest[i, 2].Trim() + ")";
                    }
                }
            }
            return strNewSql;
        }

        #endregion

        #region [ ����: ���ݹ���ID��ȡ�������� ]

        public string GetWorkTyepStr(int WorkTypeID)
        {
            string strsql=string.Format("select WtName from WorkType_Info where WorkTypeID={0}",WorkTypeID);
            return ddal.GetString(strsql);
        }
        #endregion

        #region [ ����: ��Ա��Ϣ ]
        public DataSet GetEmpInfo(int pageIndex, int pageSize, string where)
        {
            //SqlParameter[] para = { new SqlParameter("@tblName",SqlDbType.VarChar,255),
            //                        new SqlParameter("@fldName",SqlDbType.VarChar,255),
            //                        new SqlParameter("@PageSize",SqlDbType.Int),
            //                        new SqlParameter("@PageIndex",SqlDbType.Int),
            //                        new SqlParameter("@IsReCount",SqlDbType.Bit),
            //                        new SqlParameter("@OrderType",SqlDbType.Bit),
            //                        new SqlParameter("@strWhere",SqlDbType.VarChar,1000)
            //};
            //para[0].Value = "KJ128N_Emp_Table";
            //para[1].Value = "EmpID";
            //para[2].Value = pageSize;
            //para[3].Value = pageIndex;
            //para[4].Value = 1;
            //para[5].Value = 0;
            //para[6].Value = where;

            //return aedal.GetEmpInfo(para);

            return aedal.GetEmpInfo(pageIndex, pageSize, where);
        }

        #endregion

        #region [ ����: ���ű���Ϣ ]
        // ��䲿����
        public DataTable GetDeptInfo()
        {
            return aedal.GetDeptInfo();
        }

        #endregion

        #region [ ����: ɾ�� ��Ա��Ϣ ]
        /// <summary>
        /// ɾ����Ա��Ϣ
        /// </summary>
        /// <param name="WorkTypeID">��ԱID</param>
        /// <returns>����Ӱ������</returns>
        public int DeleteEmp(int EmpID)
        {
            return aedal.DeleteEmp(EmpID);
        }
        #endregion

        #region [ ����: ��ʼ��StationMakeupVspanel ]
        public StationMakeupVspanel InitSmvp(StationMakeupVspanel Smvp,string str, Point x,Size y  )
        {
            Smvp.Anchor = ((AnchorStyles.Left) | (AnchorStyles.Top) | (AnchorStyles.Right));
            Smvp.CaptionTitle = str;
            Smvp.VerticalInterval = 8;
            Smvp.LeftInterval = 22;
            Smvp.TopInterval = 8;
            Smvp.BackColor = color_BackColor;
            Smvp.IsmiddleInterval = true;
            Smvp.IsCaptionSingleColor = true;

            Smvp.IsShowAddNewStationHeadInfo = false;   //����ʾ���ӽ�����Ϊ
            Smvp.IsShowDeleteStationInfo = false;       //����ʾɾ����վ
            Smvp.IsShowEditStationInfo = false;         //����ʾ�༭��վ

            Smvp.IsShowLabelStationInfo = false;
            Smvp.LayoutType = VSPanelLayoutType.VerticalType;
            Smvp.Location = x;
            Smvp.Size = y; ;

            return Smvp;
        }
        #endregion

        #region [ ����: ��ʼ��LabelTransparent ]

        public LabelTransparent InitLabel(LabelTransparent lab, string str)
        {
            lab.Font = font_labelFont;
            lab.BackColor = color_BackColor;
            lab.Anchor = ((AnchorStyles.Left) | (AnchorStyles.Top));
            lab.Text = str;
            lab.AutoSize = true;
            lab.IsTransparent = true;
            lab.ForeColor = color_ForeColor;

            return lab;
        }
        #endregion

        #region [ ����: ��ʼ��TextBox ]

        public TextBox InitTextBox(TextBox tBox,Size y)
        {
            tBox.Anchor = ((AnchorStyles.Left) | (AnchorStyles.Top));
            tBox.Text = "";
            tBox.Size = y;

            return tBox;
        }
        #endregion

        #region [ ����: ��ʼ��CheckBox ]

        public CheckBox InitCheckBox(CheckBox chBox,string str, Size y,bool z)
        {
            chBox.Anchor = ((AnchorStyles.Left) | (AnchorStyles.Top));
            chBox.BackColor = color_BackColor;
            chBox.Text = str;
            chBox.Size = y;
            chBox.AutoSize = true;
            chBox.ForeColor = color_ForeColor;
            chBox.Font = font_labelFont;
            chBox.Checked = z;

            return chBox;
        }
        #endregion

        #region [ ����: ��ʼ��DateTimePicker ]

        public DateTimePicker InitDateTimePicker(DateTimePicker dtp, bool z)
        {
            dtp.Anchor = ((AnchorStyles.Left) | (AnchorStyles.Top));
            dtp.BackColor = color_BackColor;
            dtp.AutoSize = true;
            dtp.ForeColor = color_ForeColor;
            dtp.Enabled = z;
            dtp.Size = new Size(110, 21);
            return dtp;
        }
        #endregion

        #region [ ����: ��ʼ��RadioButton ]

        public RadioButton InitRadioButton(RadioButton raBon, string str, Point x)
        {
            raBon.Anchor = ((AnchorStyles.Left) | (AnchorStyles.Top));
            raBon.Size = new Size(53, 16);
            raBon.Font = font_labelFont;
            raBon.Text = str;
            raBon.AutoSize = true;
            raBon.ForeColor = color_ForeColor;
            raBon.Location = x;

            return raBon;
        }
        #endregion

        #region [ ����: ��ʼ��GroupBox ]

        public GroupBox InitGroupBox(GroupBox grBox, string str, Point x)
        {
            grBox.Anchor = ((AnchorStyles.Left) | (AnchorStyles.Top));
            grBox.Location = x;
            grBox.Size = new Size(98, 131);
            grBox.Font = font_labelFont;
            grBox.Text = str;
            grBox.AutoSize = true;
            grBox.ForeColor = color_ForeColor;
            grBox.BackColor = color_BackColor;

            return grBox;
        }
                #endregion

        #region [ ����: �󶨹�������(cmboBox) ]

        public ComboBox GetCerNameCmb(ComboBox cmb)
        {
            DataTable dt = aedal.GetWorkTypeTab();
            if (dt != null )
            {
                cmb.DataSource = null;
                DataRow dr = dt.NewRow();
                dr[0] = 0;
                dr[1] = "����";
                dt.Rows.InsertAt(dr, 0);
                cmb.DataSource = dt;
                cmb.DisplayMember = "WtName";
                cmb.ValueMember = "WorkTypeID";
                cmb.SelectedIndex = 0;
            }
            return cmb;
        }
        #endregion

        #region [ ����: �� ְ���ж�(comboBox) ]

        public void GetDutyNameCmb(ComboBox cmb,bool bl)
        {
            DataSet ds = GetDutyNameInfo();
            if (ds.Tables != null && ds.Tables.Count > 0)
            {
                cmb.DataSource = null;
                DataRow dr = ds.Tables[0].NewRow();
                dr[0] = 0;
                if (bl)
                {
                    dr[1] = "����";
                }
                else
                {
                    dr[1] = "��";
                }
                ds.Tables[0].Rows.InsertAt(dr, 0);
                cmb.DataSource = ds.Tables[0];
                cmb.DisplayMember = "DutyName";
                cmb.ValueMember = "DutyID";
                cmb.SelectedValue = 0;
            }
        }

        private DataSet GetDutyNameInfo()
        {
            return aedal.GetDutyNameInfo();
        }

        #endregion

        #region [ ����: �� ��������(comboBox) ]

        public void GetDeptNameCmb(ComboBox cmb)
        {
            DataSet ds = GetDeptNameInfo();
            if (ds.Tables != null && ds.Tables.Count > 0)
            {
                cmb.DataSource = null;
                DataRow dr = ds.Tables[0].NewRow();
                dr[0] = 0;
                dr[1] = "��";
                ds.Tables[0].Rows.InsertAt(dr, 0);
                cmb.DataSource = ds.Tables[0];
                cmb.DisplayMember = "DeptName";
                cmb.ValueMember = "DeptID";
                cmb.SelectedValue = 0;
            }
        }

        private DataSet GetDeptNameInfo()
        {
            return aedal.GetDeptNameInfo();
        }

        #endregion

        #region [ ����: ���ݲ��źͷ������õ�Ա������ ]

        public DataSet GetEmployeeNameByDeptIDAndCoderSenderID(int intDeptID, int intBlockID)
        {
            return aedal.GetEmployeeNameByDeptIDAndCoderSenderID(intDeptID, intBlockID);
        }
        #endregion

        #region [ ����: �����������������б�� ]

        /// <summary>
        /// ���б��
        /// </summary>
        /// <param name="list">�б��</param>
        /// <param name="textField">��ʾ����</param>
        /// <param name="valueField"></param>
        /// <param name="strWhere"></param>
        /// <param name="strErrMsg"></param>
        public void GetListBox(System.Web.UI.WebControls.ListBox list, string textField, string valueField, string strWhere, out string strErrMsg)
        {
            list.DataSource = aedal.GetDropDownList(textField, valueField, strWhere, out strErrMsg);
            list.DataTextField = textField;
            list.DataValueField = valueField;
            list.DataBind();
        }
        #endregion

        #region [ ����: ��֤���ݿ���Ա���Ƿ���� ]
        /// <summary>
        /// ��֤���ݿ���Ա���Ƿ����
        /// </summary>
        /// <param name="strEmpNO">Ա�����</param>
        /// <returns>True:����;False:������</returns>
        public bool IsEmp(string strEmpNO)
        {
            using (ds = new DataSet())
            {
                ds = aedal.IsEmpNO(strEmpNO);
                if (ds != null)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count == 1)
                    {
                        //���ڸ�Ա�����
                        return true;
                    }
                }
            }
            return false;
        }

        #endregion

       

    }
}
