using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authing.Guard.WPF.Enums
{
    /// <summary>
    /// Guard 支持的重置密码方式
    /// </summary>
    public enum ResetPwdMethods
    {
        /// <summary>
        /// 邮件验证码重置
        /// </summary>
        [Description("email")]
        Email,
        /// <summary>
        /// 手机短信验证码重置
        /// </summary>
        [Description("phone")]
        Phone
    }
}
