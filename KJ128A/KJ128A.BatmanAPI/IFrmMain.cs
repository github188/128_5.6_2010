namespace KJ128A.BatmanAPI
{
    /// <summary>
    /// 主窗体接口
    /// </summary>
    public interface IFrmMain
    {
        bool GetCommType();
        /// <summary>
        /// 获取登录者信息
        /// </summary>
        /// <returns></returns>
        string GetLoginInfo();

        /// <summary>
        /// 设置登录信息
        /// </summary>
        /// <param name="strLoginName">登录帐户</param>
        /// <returns></returns>
        bool SetLoginInfo(string strLoginName);

        /// <summary>
        /// 用户权限变更
        /// </summary>
        /// <param name="enumPower">权限级别</param>
        void MenuPowerChange(EnumPowers enumPower);

        /// <summary>
        /// 基站状态改变
        /// </summary>
        /// <param name="index">串口索引</param>
        /// <param name="iAddress">基站地址号</param>
        /// <param name="enumState">基站状态</param>
        bool Station_ChangeState(int index, int iAddress, EnumStationState enumState);

        bool Station_ChangeState(int iAddress, EnumStationState enumState);
        /// <summary>
        /// 基站配置更改
        /// </summary>
        /// <param name="index">串口索引</param>
        /// <param name="iAddress">基站地址号</param>
        /// <param name="enumOP">基站状态</param>
        /// <returns></returns>
        bool Station_Change(int index, int iAddress, EnumOP enumOP);

        /// <summary>
        /// 运行状态变更
        /// </summary>
        /// <param name="strMsg"></param>
        /// <returns></returns>
        bool DataSaver_StateChange(string strMsg);

        /// <summary>
        /// 通讯程序重启
        /// </summary>
        /// <returns></returns>
        void Reset();

        /// <summary>
        /// 返回是否主机
        /// </summary>
        /// <returns></returns>
        bool IsMainHost();
    }
}
