using System.ComponentModel;
using System.Runtime.Serialization;

namespace Authing.Guard.WPF.Enums
{
    public enum SocialConnections
    {
        /// <summary>
        /// QQ 登录
        /// </summary>
        [EnumMember(Value = "qq")]
        [Description("qq")]
        Qq,

        /// <summary>
        /// 新浪微博登录
        /// </summary>
        [EnumMember(Value = "weibo")]
        [Description("weibo")]
        Weibo,

        /// <summary>
        /// GitHub 登录
        /// </summary>
        [EnumMember(Value = "github")]
        [Description("github")]
        Github,

        /// <summary>
        /// Google 账号登录
        /// </summary>
        [EnumMember(Value = "google")]
        [Description("google")]
        Google,

        /// <summary>
        /// 微信 PC 端登录
        /// </summary>
        [EnumMember(Value = "wechat:pc")]
        [Description("wechat:pc")]
        WxPc,

        /// <summary>
        /// 钉钉登录
        /// </summary>
        [EnumMember(Value = "dingtalk")]
        [Description("dingtalk")]
        Dingtalk,

        /// <summary>
        /// 企业微信二维码登录
        /// </summary>
        [EnumMember(Value = "wechatwork:corp:qrconnect")]
        [Description("wechatwork:corp:qrconnect")]
        WxWCorpQr,

        /// <summary>
        /// 企业微信第三方应用扫码授权登录
        /// </summary>
        [EnumMember(Value = "wechatwork:service-provider:qrconnect")]
        [Description("wechatwork:service-provider:qrconnect")]
        WxWSPQr,

        /// <summary>
        /// 企业微信第三方应用网页授权登录
        /// </summary>
        [EnumMember(Value = "wechatwork:service-provider:authorization")]
        [Description("wechatwork:service-provider:authorization")]
        WxWSPAuth,

        /// <summary>
        /// gitee 登录
        /// </summary>
        [EnumMember(Value = "gitee")]
        [Description("gitee")]
        Gitee,

        /// <summary>
        /// 飞书 登录
        /// </summary>
        [EnumMember(Value = "lark-internal")]
        [Description("lark-internal")]
        LarkInternal,
       
}
}