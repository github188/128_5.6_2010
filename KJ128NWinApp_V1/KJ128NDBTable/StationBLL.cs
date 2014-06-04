using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using KJ128NDataBase;
using KJ128WindowsLibrary;
using System.Windows.Forms;
using System.Drawing;

namespace KJ128NDBTable
{
    public class StationBLL
    {

        #region [ ���� ]

        private StationDAL sdal = new StationDAL();
        private EnumInfoDAL eidal = new EnumInfoDAL();
        private RealTimeDAL rtdal = new RealTimeDAL();

        #endregion


        #region [ ����: �ж��Ƿ������� ]

        /// <summary>
        ///  �ж��Ƿ�������
        /// </summary>
        /// <param name="str">�ַ�ת</param>
        /// <returns>�Ƿ�������</returns>
        public bool IsNumeric(string str)
        {
            if (str == null || str.Length == 0)
                return false;
            foreach (char c in str)
            {
                if (!Char.IsNumber(c))
                {
                    return false;
                }
            }
            return true;
        }

        #endregion

        #region [ ����: �ж��Ƿ��ǵ绰 ]

        /// <summary>
        ///  
        /// </summary>
        /// <param name="str">�ַ�ת</param>
        /// <returns></returns>
        public bool IsTel(string str)
        {
            if (str == null || str.Length == 0)
                return false;
            foreach (char c in str)
            {
                if (!Char.IsNumber(c))
                {
                    if (c != '-')
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        #endregion

        #region [ ����: ��վ��Ϣ���� ]

        #region ��ӷ�վ��ַ��

        public void addSatationAddress(int min, int max, string place, string tel, int typeId, string typeName, int group, bool enabledBatch, out string result)
        {
            if (min == 0) { result = HardwareName.Value(CorpsName.StationAddress)+"����Ϊ0"; return; }
            string stationArr = string.Empty;
            //�ж��Ƿ����������
            if (enabledBatch)
            {
                if (max <= min) { result = HardwareName.Value(CorpsName.StationAddress)+"��ΧӦ��С���� ��:1-10"; return; }
                // ��֯��վ��ַ�б�
                if (max - min > 100) { result = "��վ�������һ�����100����վ"; return; };
                for (int i = min; i <= max; i++)
                {
                    if (i < max)
                        stationArr += i.ToString() + ",";
                    else
                        stationArr += i.ToString();
                }

                // ���
                DataTable dt = sdal.getExistsStationAddress(stationArr);
                //���
                int resultInt = sdal.insertStationAddress(stationArr, place, tel, typeId, typeName, group);

                // ��ӳɹ��� �õ��ظ��ķ�վ��ַ
                StringBuilder tempString = new StringBuilder();
                if (dt.Rows.Count == max)
                {
                    result = HardwareName.Value(CorpsName.StationAddress)+ "ȫ������";
                }
                else if (dt.Rows.Count > 0 && dt.Rows.Count < max)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        tempString.Append(dr["col"].ToString() + ",");
                    }
                    tempString = tempString.Remove(tempString.Length - 1, 1);
                    result = tempString.Append(" ���Ѿ�����,��������ӳɹ�").ToString();
                }
                else if (resultInt == -1)
                {
                    result = "���ʧ��";
                }
                else
                {
                    result = "��ӳɹ�";
                }
                return;
            }
            else
            {
                //�жϷ�վ��ַ���Ƿ����
                if (sdal.existsStationAddress(min) >= 1)
                {
                    result = HardwareName.Value(CorpsName.StationAddress)+":" + min.ToString() + "�Ѿ�����,���������";
                    return;
                }
                else
                {
                    stationArr = min.ToString();
                    //���
                    if (sdal.insertStationAddress(stationArr, place, tel, typeId, typeName, group) >= 1)
                    {
                        result = "��ӳɹ�";
                        return;
                    }
                    else
                    {
                        result = "���ʧ��";
                        return;
                    }
                }
            }
        }

        #endregion

        #region ��÷�վ����Table

        public DataTable getStationTypeTab()
        {
            return eidal.getEnumInfo(1);
        }

        #endregion

        #region ���յ�ַ�Ż�÷�վ��Ϣreturn DataRow

        public DataRow getStationInfo(int stationAddress)
        {
            return sdal.getStationInfo(stationAddress);
        }

        #endregion

        #region ��ӽ����� return int

        public int insertStationHead(int stationAddress, int shAddress, string shPlace, string shTel, int shTypeId, string shType, string antennaA, string antennaB, string remark)
        {
            return sdal.insertStationHead(stationAddress, shAddress, shPlace, shTel, shTypeId, shType, 0, 0, 1, antennaA, antennaB, remark);
        }

        #endregion

        #region �鿴��������ַ���Ƿ��Ѵ��� return int

        public int existsStationHeadAddress(int addressHead, int address)
        {
            return sdal.existsStationHeadAddress(addressHead, address);
        }

        #endregion

        #region ��վ�ͽ�������

        public DataSet getStationHeadInfo(int pageIndex, int pageSize)
        {
            return sdal.getStationHeadInfo(pageIndex, pageSize);
        }

        #endregion

        #region ���ָ����վ�Ľ�����

        public DataTable getStationHeadInfoAll(int stationAddress)
        {
            return sdal.getStationHeadInfoAll(stationAddress);
        }

        #endregion

        #region ɾ��������

        public int deleteStationHead(int id)
        {
            return sdal.deletdStationHead(id);
        }

        #endregion

        #region �޸ķ�վ��Ϣ

        public int updateStation(int sAddress, string place, string tel, int typeId, string typeName, int group)
        {
            return sdal.updateStation(sAddress, place, tel, typeId, typeName, group);
        }

        #endregion

        #region ��øý�������Ϣ return DataRow

        public DataRow getStationHeadRowInfo(int id)
        {
            return sdal.getStationHeadRowInfo(id);
        }

        #endregion

        #region �޸Ľ�������Ϣ

        public int updateStationHead(int headId, string shPlace, string shTel, int shTypeId, string shType, string antennaA, string antennaB, string remark)
        {
            return sdal.updateStationHead(headId, shPlace, shTel, shTypeId, shType, antennaA, antennaB, remark);
        }

        #endregion

        #region ɾ����վ��Ϣ

        public int deleteStation(int stationAddress)
        {
            //sdal.deleteStationHeads(stationAddress);//ɾ���÷�վ�����н�����
            return sdal.deleteStation(stationAddress);
        }

        #endregion

        #endregion

        #region [ ����: ��վ��Ϣ��ʾ ]

        #region ��ȡ��վʵʱ��Ϣ
        /// <summary>
        /// ��վ��Ϣ
        /// </summary>
        /// <param name="pageIndex">ҳ��</param>
        /// <param name="pageSize">ÿҳ����</param>
        /// <param name="sumType">��ʾ���� 0��Ա 1�豸 2��</param>
        /// <returns></returns>
        public DataSet GetRTStationInfo(int pageIndex, int pageSize, int sumType)
        {
            SqlParameter[] para = {new SqlParameter("@pageIndex",SqlDbType.Int),
                                new SqlParameter("@pageSize",SqlDbType.Int),
                                new SqlParameter("@sumType",SqlDbType.Int)
            };
            para[0].Value = pageIndex;
            para[1].Value = pageSize;
            para[2].Value = sumType;
            return sdal.GetRTStationInfo(para);
        }

        /// <summary>
        /// ��վ��������Ϣ
        /// </summary>
        /// <param name="addressList">��վ�б�(1,2,3)</param>
        /// <returns>StationAddress,StationHeadAddress,InStationHeadAntenna,SumCard</returns>
        public DataSet GetRTStationHeadInfo(string addressList, int sumType)
        {
            SqlParameter[] para = {new SqlParameter("@addressList",SqlDbType.VarChar,2000),
                                new SqlParameter("@sumType",SqlDbType.Int)
            };
            para[0].Value = addressList;
            para[1].Value = sumType;
            return sdal.GetRTStationHeadInfo(para);
        }

        /// <summary>
        /// ��վ��������Ϣ
        /// </summary>
        /// <param name="pageIndex">ҳ������</param>
        /// <param name="pageSize">ÿҳ�߶�</param>
        /// <param name="sumType">ͳ������</param>
        /// <returns>����ʵʱ��ʾ��������Ϣ</returns>
        public DataSet GetRTDisplayStationHeadInfo(int pageIndex, int pageSize, int sumType)
        {
            SqlParameter[] para = {new SqlParameter("@pageIndex",SqlDbType.Int),
                                new SqlParameter("@pageSize",SqlDbType.Int),
                                new SqlParameter("@sumType",SqlDbType.Int)
            };
            para[0].Value = pageIndex;
            para[1].Value = pageSize;
            para[2].Value = sumType;
            return sdal.GetRTDisplayStationHeadInfo(para);
        }
        #endregion

        #region ������Ϣ

        public DataSet GetRTDeptSmallInfo(int displayType)
        {
            SqlParameter[] para = { new SqlParameter("@displayType", SqlDbType.Int) };
            para[0].Value = displayType;
            return sdal.GetRTDeptSmallInfo(para);
        }

        #endregion

        #endregion

        #region ��������������Ӽ��ж��Ƿ����

        public int addDirectionalAntenna(string detectionInfo, string directional)
        {
            return sdal.addDirectionalAntenna(detectionInfo, directional);
        }

        #endregion

        #region �������������޸�

        public int upDateDirectionalAntenna(int CodeSenderDirlID, string Directional)
        {
            return sdal.upDateDirectionalAntenna(CodeSenderDirlID, Directional);
        }

        #endregion

        #region ������������ɾ��

        public int removeDirectionalAntenna(int CodeSenderDirlID)
        {
            return sdal.removeDirectionalAntenna(CodeSenderDirlID);
        }

        #endregion

        #region [ ����: �����Թ��� ]

        #region FrmDirectional��÷�վ�ͽ���������

        public DataSet GetStationAndHead()
        {
            return sdal.GetStationAndHead();
        }

        #endregion

        #region �жϷ������Ƿ����

        public int existsDirectional(string dStr)
        {
            return sdal.existsDirectional(dStr);
        }

        #endregion

        #region ��������Ӽ��ж��Ƿ����

        public int addDirectional(string detectionInfo, string directional)
        {
            return sdal.addDirectional(detectionInfo, directional);
        }

        #endregion

        #region ������õķ�����

        public DataSet getAllDirectional(int pageIndex, int pageSize, string where)
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
            para[0].Value = "View_GetAllDirectional";
            para[1].Value = "DetectionInfo";
            para[2].Value = "CodeSenderDirlID as ������,DetectionInfo as ��ʶ,DetectionPlace as λ��,Directional as ����������";//
            para[3].Value = "DetectionInfo";
            para[4].Value = pageIndex;
            para[5].Value = pageSize;
            para[6].Value = where;
            para[7].Value = 0;

            return rtdal.getRTDeptInfo(para);
        }

        #endregion

        #region ������õķ�����

        public DataSet getAllDirectionalAntenna(int pageIndex, int pageSize, string where)
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
            para[0].Value = "View_GetAllDirectionalAntenna";
            para[1].Value = "DetectionInfo";
            para[2].Value = "CodeSenderDirlID as ������,DetectionInfo as ��ʶ,DetectionPlace as λ��,Directional as ����������";//
            para[3].Value = "DetectionInfo";
            para[4].Value = pageIndex;
            para[5].Value = pageSize;
            para[6].Value = where;
            para[7].Value = 0;

            return rtdal.getRTDeptInfo(para);
        }

        #endregion

        #region ������ɾ��

        public int removeDirectional(int CodeSenderDirlID)
        {
            return sdal.removeDirectional(CodeSenderDirlID);
        }

        #endregion

        #region �������޸�

        public int upDateDirectional(int CodeSenderDirlID, string Directional)
        {
            return sdal.upDateDirectional(CodeSenderDirlID, Directional);
        }

        #endregion

        #endregion

        #region [ ����: �õ�������վ��Ϣ ]
        public void GetOutWellStationInfo(ComboBox CB)
        {
            string strErr = string.Empty;
            DataSet ds = sdal.GetOutWellStationInfo(out strErr);

            CB.Items.Clear();
            if (ds.Tables[0].Rows.Count == 0)
            {
                DataRow dr = ds.Tables[0].NewRow();
                dr[0] = "0";
                dr[1] = "��";
                ds.Tables[0].Rows.InsertAt(dr, 0);
            }

            CB.DataSource = ds.Tables[0];
            CB.DisplayMember = "StationHeadPlace";
            CB.ValueMember = "StationAddressAndStationHeadAddress";

        }
        #endregion

    }
}
