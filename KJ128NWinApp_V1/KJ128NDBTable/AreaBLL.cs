using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using KJ128NDataBase;
using KJ128WindowsLibrary;
using System.Windows.Forms;
using System.Drawing;
using KJ128NInterfaceShow;

namespace KJ128NDBTable
{
    public class AreaBLL
    {
        #region [ ���� ]
        private AreaDAL areadal = new AreaDAL();
        private EnumInfoDAL eidal = new EnumInfoDAL();
        private DeptDAL ddal = new DeptDAL();
        #endregion

        #region [ ����: ɾ�������� ]

        public void DeleteStationHead(int stationHead)
        {
            areadal.DeleteStationHead(stationHead);
        }

        #endregion

        #region [ ����: ɾ�������� ]

        public void DeleteStation(int intValue)
        {
            areadal.DeleteStation(intValue);
        }

        #endregion

        #region [ KJ128N_TerSet_Head_Table ]

        public DataSet GetTerSetHeadTable(int temp_TerID)
        {
            return areadal.GetTerSetHeadTable(temp_TerID);
        }

        #endregion

        #region [ ����: KJ128N_Station_Info_Select_TreeView ]

        public DataSet GetStationInfoTreeView()
        {
            return areadal.GetStationInfoTreeView();
        }

        #endregion

        #region [ ����: �������� ]

        public void EditArea(int id, int intSta, int intHead, int isTerrEnter)
        {
            areadal.EditArea(id, intSta, intHead, isTerrEnter);
        }

        #endregion

        #region [ ����: ɾ���������� ]

        public void RemoveAreaSet(int int_TerSet)
        {
            areadal.RemoveAreaSet( int_TerSet);
            
        }

        #endregion

        #region [ ����: select * from KJ128N_TerInfo_Table ]

        public DataSet GetTreInfoTable(string strTerInfoName)
        {
            return areadal.GetTreInfoTable(strTerInfoName);
        }

        #endregion

        #region [ ����: KJ128N_TerType_Table ]

        public DataSet GetKJ128NTerTypeTable(string strTerTypeName)
        {
            return areadal.GetKJ128NTerTypeTable(strTerTypeName);
        }

        #endregion

        #region [ ����: ��� ������Ϣ ]

        public int SaveTerInfoData(string TerName, int TerTypeID, byte IsEnable, string Instruction, string Remark)
        {
            return areadal.SaveTerInfoData(TerName, TerTypeID, IsEnable, Instruction, Remark);
        }
        #endregion

        #region [ ����: �޸� ������Ϣ ]
        public int UpDateTerInfo(int TerInfoID, string TerName, int TerTypeID, byte IsEnable, string Instruction, string Remark)
        {
            return areadal.UpDateTerInfo(TerInfoID, TerName, TerTypeID, IsEnable, Instruction, Remark);
        }
        #endregion

        #region [ ����: ɾ�� ������Ϣ ]
        public int DeleteTerInfo(int TerInfoID)
        {
            return areadal.DeleteTerInfo(TerInfoID);
        }
        #endregion

        #region [ ����: ��� ������� ]
        public int SaveTerTypeData(string TypeName, byte IsAlarm, string Remark)
        {
            return areadal.SaveTerTypeData(TypeName, IsAlarm, Remark);
        }
        #endregion

        #region [ ����: �޸� ������Ϣ ]
        public int UpDateTerType(int TerTypeID, string TypeName, byte IsAlarm, string Remark)
        {
            return areadal.UpDateTerType(TerTypeID, TypeName, IsAlarm, Remark);
        }
        #endregion

        #region [ ����: ɾ�� ������Ϣ ]
        public int DeleteTerType(int TerTypeID)
        {
            return areadal.DeleteTerType(TerTypeID);
        }
        #endregion

        #region [ ����: �� ������𣨷���"����"�� ]
        public ComboBox GetTerTypeCmb1(ComboBox cmb)
        {
            DataSet ds = areadal.GetTerTypeDataSet();
            if (ds.Tables != null && ds.Tables.Count > 0)
            {
                cmb.DataSource = null;
                DataRow dr = ds.Tables[0].NewRow();
                dr[0] = 0;
                dr[1] = "����";
                ds.Tables[0].Rows.InsertAt(dr, 0);
                cmb.DataSource = ds.Tables[0];
                cmb.DisplayMember = "TypeName";
                cmb.ValueMember = "TerritorialTypeID";
            }
            return cmb;
        }
        #endregion

        #region [ ����: �� �������(������"����") ]
        public ComboBox GetTerTypeCmb2(ComboBox cmb)
        {
            DataSet ds = areadal.GetTerTypeDataSet();
            if (ds.Tables != null && ds.Tables[0].Rows.Count > 0)
            {
                cmb.DataSource = null;
                DataRow dr = ds.Tables[0].NewRow();
                cmb.DataSource = ds.Tables[0];
                cmb.DisplayMember = "TypeName";
                cmb.ValueMember = "TerritorialTypeID";
            }
            return cmb;
        }
        #endregion

        #region [ ����: �� �������� ]
        public ComboBox GetTerNameCmb(ComboBox cmb)
        {
            DataSet ds = areadal.GetTerNameDataSet();
            if (ds.Tables != null && ds.Tables.Count > 0)
            {
                cmb.DataSource = null;
                DataRow dr = ds.Tables[0].NewRow();
                dr[0] = 0;
                dr[1] = "����";
                ds.Tables[0].Rows.InsertAt(dr, 0);
                cmb.DataSource = ds.Tables[0];
                cmb.DisplayMember = "TerritorialName";
                cmb.ValueMember = "TerritorialID";
            }
            return cmb;
        }
        #endregion

        #region [ ����: �����������ͣ�������������(DataTable) ]
        public DataTable GetTerTypeSetTable( int TerTypeID)
        {
            return  areadal.GetTerTypeSetTable(TerTypeID);
        }
        #endregion

        #region [ ����: �����������ƣ�������������(DataTable) ]
        public DataTable GetTerNameSetTable(int TerNameID)
        {
            return areadal.GetTerNameSetTable(TerNameID);
        }
        #endregion

        #region [ ����: ���������������� ]
        public DataTable GetTerSetTable()
        {
            return areadal.GetTerSetTable();
        }
        #endregion

        #region [ ����: ����������Ϣ ]
        public DataTable GetTerInfoTable()
        {
            return areadal.GetTerInfoTable();
        }
        #endregion

        #region [ ����: ����������� ]
        public DataTable GetTerTypeTable()
        {
            return areadal.GetTerTypeTable();
        }
        #endregion

        #region [ ����: ����������Ϣ ]
        public DataSet GetTerSet(int pageIndex, int pageSize, string where)
        {
            SqlParameter[] para = { new SqlParameter("@tblName",SqlDbType.VarChar,255),
                                    new SqlParameter("@fldName",SqlDbType.VarChar,255),
                                    new SqlParameter("@PageSize",SqlDbType.Int),
                                    new SqlParameter("@PageIndex",SqlDbType.Int),
                                    new SqlParameter("@IsReCount",SqlDbType.Bit),
                                    new SqlParameter("@OrderType",SqlDbType.Bit),
                                    new SqlParameter("@strWhere",SqlDbType.VarChar,1000)
            };
            para[0].Value = "KJ128N_TerTypeSet_Table";
            para[1].Value = "TerritorialSetID";
            para[2].Value = pageSize;
            para[3].Value = pageIndex;
            para[4].Value = 1;
            para[5].Value = 0;
            para[6].Value = where;

            return areadal.GetTerSet(para);
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
            for (int i = 0; i < strTest.GetUpperBound(0) + 1; i++)
            {
                if (strTest[i, 2].Trim() != string.Empty)
                {
                    if (strTest[i, 3].Trim() == "string")
                    {
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
                        strNewSql = strTest[i, 0].Trim() + " " + strTest[i, 1].Trim() + " " + strTest[i, 2].Trim();
                        blnFirst = false;
                    }
                    else
                    {
                        strNewSql += " and " + strTest[i, 0].Trim() + " " + strTest[i, 1].Trim() + " " + strTest[i, 2].Trim();
                    }
                }
            }
            return strNewSql;
        }

        #endregion

        #region [ ����: ���ӵ�ǰ������ ]
        public TreeView TrTerStaHead(TreeView tr,DataTable dt, int intSta, int intHead)
        {
            foreach (DataRow dr in dt.Rows)
            {
                int int_StationID = (int)dr["StationID"];
                int int_StationHeadID;
                if (dr["StationHeadID"].ToString().CompareTo("")==0)
                {
                    int_StationHeadID = 0;
                }
                else
                {
                    int_StationHeadID = Convert.ToInt32(dr["StationHeadID"]);
                }
                string str_StationPlace = dr["StationPlace"].ToString();
                string str_StationHeadPlace = dr["StationHeadPlace"].ToString();
                string key = "N" + intSta;
                string str_key="H" + intHead;
                if (intHead != 0)
                {
                    if (intSta == int_StationID && intHead == int_StationHeadID)
                    {
                        if (tr.Nodes[key] != null)
                        {
                            tr.Nodes[key].Nodes.Add(str_key, str_StationHeadPlace);
                        }
                        else
                        {
                            tr.Nodes.Add(key, str_StationPlace);
                            tr.Nodes[key].Nodes.Add(str_key, str_StationHeadPlace);
                        }
                    }
                }
                else
                {
                    if (intSta == int_StationID)
                    {
                        if (tr.Nodes[key] != null)
                        {
                            tr.Nodes[key].Nodes.Add(str_key, str_StationHeadPlace);
                        }
                        else
                        {
                            tr.Nodes.Add(key, str_StationPlace);
                            tr.Nodes[key].Nodes.Add(str_key, str_StationHeadPlace);
                        }
                    }
                }
                
            }
            return tr;
        }
        #endregion

        #region [ ����: �󶨷�վ�� ]
        public TreeView TrStation(TreeView tr, DataTable dt)
        {
            //tr.Nodes.Add("root", "����");           //Ĭ����һ��ȫ���ĸ��ڵ�
            //TreeNodeCollection treeNodeColle = tr.Nodes["root"].Nodes;
            TreeNodeCollection treeNodeColle = tr.Nodes;
            int x = 0;
            foreach ( DataRow dr in dt.Rows)
            {
                
                int int_StationID =(int)dr["StationID"];
                string str_StationHeadID =Convert.ToString(dr["StationHeadID"]);
                string str_StationPlace = dr["StationPlace"].ToString();
                string str_StationHeadPlace = dr["StationHeadPlace"].ToString();
                string key = "N" + int_StationID;
                if (x == 0)
                {
                    
                    treeNodeColle.Add(key, str_StationPlace);
                    if (str_StationHeadID.CompareTo("") != 0)
                    {
                        string str_key = "H"  +Convert.ToInt32(str_StationHeadID);            //node key ȡ������key

                        treeNodeColle[key].Nodes.Add(str_key, str_StationHeadPlace);
                    }
                }
                else if (int_StationID == x && str_StationHeadID.CompareTo("") != 0)
                {
                    string str_key = "H" + Convert.ToInt32(str_StationHeadID);               //node key ȡ������key
                    treeNodeColle[key].Nodes.Add(str_key, str_StationHeadPlace);
                }
                else
                {
                    treeNodeColle.Add(key, str_StationPlace);
                    if (str_StationHeadID.CompareTo("") != 0)
                    {
                        string str_key = "H" + Convert.ToInt32(str_StationHeadID);            

                        treeNodeColle[key].Nodes.Add(str_key, str_StationHeadPlace);
                    }
                }


                x = int_StationID;
            }

            return tr;
        }
        #endregion
    }
}
