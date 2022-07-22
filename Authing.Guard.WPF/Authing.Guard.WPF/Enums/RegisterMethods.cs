using System.ComponentModel;
using System.Runtime.Serialization;

namespace Authing.Guard.WPF.Enums
{
    /// <summary>
    /// Guard 支持的注册方式
    /// </summary>
    public enum RegisterMethods
    {
        /// <summary>
        /// 邮箱密码注册
        /// </summary>
        [EnumMember(Value ="email")]
        [Description("email")]
        Email,

        /// <summary>
        /// 短信验证码注册
        /// </summary>
        [EnumMember(Value ="phone")]
        [Description("phone")]
        Phone,

        /// <summary>
        /// 邮箱验证码注册
        /// </summary>
        [EnumMember(Value = "emailCode")]
        [Description("emailCode")]
        EmailCode,
    }
}