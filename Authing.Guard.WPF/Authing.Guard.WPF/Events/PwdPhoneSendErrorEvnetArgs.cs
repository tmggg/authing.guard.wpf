using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authing.Guard.WPF.Events
{
    /// <summary>
    /// 忘记密码手机验证码发送失败事件参数
    /// </summary>
    class PwdPhoneSendErrorEvnetArgs : EventArgs
    {
        /// <summary>
        /// 错误信息
        /// </summary>
        public string Error { get; set; }
    }
}
