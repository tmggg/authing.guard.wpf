using System;

namespace Authing.Guard.WPF.Events
{
    /// <summary>
    /// 重置密码失败事件参数
    /// </summary>
    internal class PwdResetErrorEventArgs : EventArgs
    {
        /// <summary>
        /// 错误信息
        /// </summary>
        public string Error { get; set; }
    }
}