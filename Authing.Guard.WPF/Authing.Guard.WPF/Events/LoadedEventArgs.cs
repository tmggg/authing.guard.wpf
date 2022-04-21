using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Authing.ApiClient.Domain.Client.Impl.AuthenticationClient;

namespace Authing.Guard.WPF.Events
{
    /// <summary>
    /// Authing appId 验证通过，加载完成
    /// </summary>
    class LoadedEventArgs : EventArgs
    {
        /// <summary>
        /// AuthenticationClient 对象，可直接操作 login， register，
        /// </summary>
        public AuthenticationClient authClient { get; set; }
    }
}
