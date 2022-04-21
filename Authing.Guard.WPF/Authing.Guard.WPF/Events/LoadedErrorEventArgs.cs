using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authing.Guard.WPF.Events
{
    /// <summary>
    /// Authing appId 验证失败，加载失败的参数
    /// </summary>
    class LoadedErrorEventArgs : EventArgs
    {
        /// <summary>
        /// 错误信息
        /// </summary>
        public string Error { get; set; }
    }
}
