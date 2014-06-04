using System;
using System.Collections.Generic;
using System.Text;

namespace KJ128A.SwitchDatabase
{
    public class SwitchDatabase
    {
        #region [事件声明]
        /// <summary>
        /// 声明开始切换数据库事件
        /// </summary>
        /// <param name="isHost">true 为正在切换主数据库   false 正在切换备用数据库</param>
        public delegate void BeginSwitchDatabaseEventHandler(bool isHost);
        /// <summary>
        /// 开始切换数据库事件
        /// </summary>
        public event BeginSwitchDatabaseEventHandler BeginSwitchDatabase;

        /// <summary>
        /// 声明结束切换数据库事件
        /// </summary>
        /// <param name="isHost">true 切换主数据库   false 切换备用数据库</param>
        public delegate void EndSwitchDatabaseEventHandler(bool isHost);
        /// <summary>
        /// 结束切换数据库事件
        /// </summary>
        public event EndSwitchDatabaseEventHandler EndSwitchDatabase;
        #endregion

        public void EndSwitchDatabaseFunction(bool isHost)
        {
            if (EndSwitchDatabase != null)
            {
                EndSwitchDatabase(isHost);
            }
            
        }

        public void BeginSwitchDatabaseFunction(bool isHost)
        {
            if (BeginSwitchDatabase != null)
            {
                BeginSwitchDatabase(isHost);
            }
        }
    }
}
