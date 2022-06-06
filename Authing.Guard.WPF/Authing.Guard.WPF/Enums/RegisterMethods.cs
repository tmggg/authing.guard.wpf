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
        /// 邮箱注册
        /// </summary>
        [EnumMember(Value ="email")]
        [Description("email")]
        Email,

        /// <summary>
        /// 手机验证码注册
        /// </summary>
        [EnumMember(Value ="phone")]
        [Description("phone")]
        Phone
    }
}