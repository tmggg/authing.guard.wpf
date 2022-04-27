using System.ComponentModel;

namespace Authing.Guard.WPF.Enums
{
    /// <summary>
    /// Guard 支持的普通登录方式
    /// </summary>
    public enum LoginMethod
    {
        /// <summary>
        /// LDAP 身份目录登录（需要配置 LDAP 服务）
        /// </summary>
        [Description("ldap")]
        LDAP,

        /// <summary>
        /// APP 扫码登录（需要接入 APP 扫码登录）
        /// </summary>
        [Description("app - qrcode")]
        AppQr,

        /// <summary>
        /// 账号密码登录(包括手机号 + 密码、邮箱 + 密码、用户名 + 密码。)
        /// </summary>
        [Description("password")]
        Password,

        /// <summary>
        /// 手机验证码登录
        /// </summary>
        [Description("phone-code")]
        PhoneCode,

        /// <summary>
        /// 微信小程序扫码登录
        /// </summary>
        [Description("wechat-miniprogram-qrcode")]
        WxMinQr,

        /// <summary>
        /// AD 用户目录登录
        /// </summary>
        [Description("ad")]
        AD
    }
}