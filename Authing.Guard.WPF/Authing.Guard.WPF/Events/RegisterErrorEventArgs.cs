using System;

namespace Authing.Guard.WPF.Events
{
    /// <summary>
    /// 用户注册失败事件参数
    /// </summary>
    internal class RegisterErrorEventArgs : EventArgs
    {
        /// <summary>
        /// 错误信息，包含字段缺失／非法或服务器错误等信息
        /// </summary>
        public string Error { get; set; }
    }
}