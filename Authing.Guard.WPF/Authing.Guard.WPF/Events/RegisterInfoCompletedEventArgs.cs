using Authing.ApiClient.Domain.Client.Impl.AuthenticationClient;
using System;

namespace Authing.Guard.WPF.Events
{
    /// <summary>
    /// 注册补充成功事件
    /// </summary>
    internal class RegisterInfoCompletedEventArgs : EventArgs
    {
        /// <summary>
        /// 用户信息
        /// </summary>
        public string User { get; set; }

        /// <summary>
        /// 补充的自定义字段信息
        /// </summary>
        public string Udfs { get; set; }

        /// <summary>
        /// AuthenticationClient 对象，可直接操作 login， register，
        /// </summary>
        public AuthenticationClient authClient { get; set; }
    }
}