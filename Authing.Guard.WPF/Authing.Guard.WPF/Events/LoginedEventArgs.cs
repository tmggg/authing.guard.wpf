using Authing.ApiClient.Domain.Client.Impl.AuthenticationClient;
using System;

namespace Authing.Guard.WPF.Events
{
    /// <summary>
    /// 用户登录成功事件参数
    /// </summary>
    internal class LoginedEventArgs : EventArgs
    {
        /// <summary>
        /// 用户信息
        /// </summary>
        public string User { get; set; }

        /// <summary>
        /// AuthenticationClient 对象，可直接操作 login， register，
        /// </summary>
        public AuthenticationClient authClient { get; set; }
    }
}