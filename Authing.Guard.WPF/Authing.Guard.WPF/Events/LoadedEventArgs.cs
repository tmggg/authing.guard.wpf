using Authing.ApiClient.Domain.Client.Impl.AuthenticationClient;
using Authing.Guard.WPF.Events.EventAggreator;
using System;

namespace Authing.Guard.WPF.Events
{
    /// <summary>
    /// Authing appId 验证通过，加载完成
    /// </summary>
    internal class LoadedEventArgs : EventArgs
    {
        /// <summary>
        /// AuthenticationClient 对象，可直接操作 login， register，
        /// </summary>
        public AuthenticationClient authClient { get; set; }
    }
}