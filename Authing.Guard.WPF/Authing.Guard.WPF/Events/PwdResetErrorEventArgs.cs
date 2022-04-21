using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authing.Guard.WPF.Events
{
    /// <summary>
    /// 重置密码失败事件参数
    /// </summary>
    class PwdResetErrorEventArgs : EventArgs
    {
        /// <summary>
        /// 错误信息
        /// </summary>
        public string Error { get; set; }
    }
}
