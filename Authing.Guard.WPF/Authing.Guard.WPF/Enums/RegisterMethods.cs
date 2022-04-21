using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authing.Guard.WPF.Enums
{
    /// <summary>
    /// Guard 支持的注册方式
    /// </summary>
    public enum RegisterMethods
    {
        /// <summary>
        /// 邮箱注册
        /// </summary>
        [Description("email")]
        Email,
        /// <summary>
        /// 手机验证码注册
        /// </summary>
        [Description("phone")]
        Phone
    }
}
