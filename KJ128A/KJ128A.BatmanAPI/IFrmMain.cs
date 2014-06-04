namespace KJ128A.BatmanAPI
{
    /// <summary>
    /// ������ӿ�
    /// </summary>
    public interface IFrmMain
    {
        bool GetCommType();
        /// <summary>
        /// ��ȡ��¼����Ϣ
        /// </summary>
        /// <returns></returns>
        string GetLoginInfo();

        /// <summary>
        /// ���õ�¼��Ϣ
        /// </summary>
        /// <param name="strLoginName">��¼�ʻ�</param>
        /// <returns></returns>
        bool SetLoginInfo(string strLoginName);

        /// <summary>
        /// �û�Ȩ�ޱ��
        /// </summary>
        /// <param name="enumPower">Ȩ�޼���</param>
        void MenuPowerChange(EnumPowers enumPower);

        /// <summary>
        /// ��վ״̬�ı�
        /// </summary>
        /// <param name="index">��������</param>
        /// <param name="iAddress">��վ��ַ��</param>
        /// <param name="enumState">��վ״̬</param>
        bool Station_ChangeState(int index, int iAddress, EnumStationState enumState);

        bool Station_ChangeState(int iAddress, EnumStationState enumState);
        /// <summary>
        /// ��վ���ø���
        /// </summary>
        /// <param name="index">��������</param>
        /// <param name="iAddress">��վ��ַ��</param>
        /// <param name="enumOP">��վ״̬</param>
        /// <returns></returns>
        bool Station_Change(int index, int iAddress, EnumOP enumOP);

        /// <summary>
        /// ����״̬���
        /// </summary>
        /// <param name="strMsg"></param>
        /// <returns></returns>
        bool DataSaver_StateChange(string strMsg);

        /// <summary>
        /// ͨѶ��������
        /// </summary>
        /// <returns></returns>
        void Reset();

        /// <summary>
        /// �����Ƿ�����
        /// </summary>
        /// <returns></returns>
        bool IsMainHost();
    }
}
