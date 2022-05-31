using System.ComponentModel;
using System.Runtime.Serialization;

namespace Authing.Guard.WPF.Enums
{
    /// <summary>
    /// Guard 支持的普通登录方式
    /// </summary>
    public enum LoginMethods
    {
        /// <summary>
        /// LDAP 身份目录登录（需要配置 LDAP 服务）
        /// </summary>
        [EnumMember(Value ="LADP 登录")]
        [Description("ldap")]
        LDAP,

        /// <summary>
        /// APP 扫码登录（需要接入 APP 扫码登录）
        /// </summary>
        [EnumMember(Value = "app - qrcode")]
        [Description("APP 扫码")]
        AppQr,

        /// <summary>
        /// 账号密码登录(包括手机号 + 密码、邮箱 + 密码、用户名 + 密码。)
        /// </summary>
        [EnumMember(Value = "password")]
        [Description("密码登录")]
        Password,

        /// <summary>
        /// 手机验证码登录
        /// </summary>
        [EnumMember(Value = "phone-code")]
        [Description("短信验证码")]
        PhoneCode,

        /// <summary>
        /// 微信小程序扫码登录
        /// </summary>
        [EnumMember(Value = "wechat-miniprogram-qrcode")]
        [Description("微信小程序")]
        WxMinQr,

        /// <summary>
        /// AD 用户目录登录
        /// </summary>
        [EnumMember(Value="ad")]
        [Description("AD 登录")]
        AD
    }
}