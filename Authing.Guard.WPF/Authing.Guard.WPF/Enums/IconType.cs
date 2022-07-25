using System.Runtime.Serialization;

namespace Authing.Guard.WPF.Enums
{
    public enum IconType
    {
        /// <summary>
        /// 默认的空白
        /// </summary>
        Blank = 1,

        /// <summary>
        /// 账号
        /// </summary>
        Account,

        /// <summary>
        /// 密码
        /// </summary>
        Password,

        /// <summary>
        /// 验证码
        /// </summary>
        VerifyCode,

        /// <summary>
        /// 显示密码
        /// </summary>
        OpenEye,

        /// <summary>
        /// 隐藏密码
        /// </summary>
        CloseEye,
        /// <summary>
        /// 成功提示
        /// </summary>
        Success,
        /// <summary>
        /// 错误提示
        /// </summary>
        Error,
        /// <summary>
        /// Gitlab
        /// </summary>
        [EnumMember(Value = "github")]
        Gitlab,
        /// <summary>
        /// YuYan
        /// </summary>
        [EnumMember(Value = "yuyan")]
        YuYan,
        /// <summary>
        /// 安卓图标
        /// </summary>
        [EnumMember(Value = "anzhuo")]
        AnZhuo,
        /// <summary>
        /// 飞书图标
        /// </summary>
        [EnumMember(Value = "lark-public")]
        LarkPublic,
        /// <summary>
        /// 飞书图标
        /// </summary>
        [EnumMember(Value = "lark-internal")]
        LarkInternal,
        /// <summary>
        /// 关闭图标
        /// </summary>
        [EnumMember(Value = "CloseWithCircle")]
        CloseWithCircle,
        /// <summary>
        /// 关闭图标没有圆圈
        /// </summary>
        [EnumMember(Value = "CloseWithoutCircle")]
        CloseWithoutCircle,
        /// <summary>
        /// 苹果图标网页版
        /// </summary>
        [EnumMember(Value = "apple:web")]
        AppleWeb,
        /// <summary>
        /// 谷歌登录
        /// </summary>
        [EnumMember(Value = "google")]
        Google,
        /// <summary>
        /// 钉钉登录
        /// </summary>
        [EnumMember(Value = "dingtalk")]
        DingTalk,
        /// <summary>
        /// 苹果登录
        /// </summary>
        [EnumMember(Value = "apple")]
        Apple,
        /// <summary>
        /// 支付宝登录
        /// </summary>
        [EnumMember(Value = "alipay:web")]
        AplipayWeb,
        /// <summary>
        /// 微信小程序启动
        /// </summary>
        [EnumMember(Value = "WechatMiniprogramAppLaunch")]
        WechatMiniprogramAppLaunch,
        /// <summary>
        /// 腾讯 QQ 登录
        /// </summary>
        [EnumMember(Value = "qq")]
        QQ,
        /// <summary>
        /// 微信手机端登录
        /// </summary>
        [EnumMember(Value = "wechat:mobile")]
        WechatMobile,
        /// <summary>
        /// 百度登录
        /// </summary>
        [EnumMember(Value = "baidu")]
        Baidu,
        /// <summary>
        /// 微信 PC 
        /// </summary>
        [EnumMember(Value = "wechat:pc")]
        WechatPC,
        /// <summary>
        /// 微信小程序扫码
        /// </summary>
        [EnumMember(Value = "WechatMiniprogramQrconnec")]
        WechatMiniprogramQrconnec,
        /// <summary>
        /// 微信网页授权
        /// </summary>
        [EnumMember(Value = "WechatWebpageAuthorization")]
        WechatWebpageAuthorization,
        /// <summary>
        /// 微信默认小程序
        /// </summary>
        [EnumMember(Value = "gitlab")]
        WechatMiniprogramDefault,
        /// <summary>
        /// 企业微信第三方应用网页授权登录
        /// </summary>
        [EnumMember(Value = "wechatwork:service-provider:authorization")]
        WechatworkServiceProviderAuthorization,
        /// <summary>
        /// 企业微信二维码登录
        /// </summary>
        [EnumMember(Value = "wechatwork:corp:qrconnect")]
        WechatworkCorpQrconnect,
        /// <summary>
        /// 企业微信第三方应用扫码授权登录
        /// </summary>
        [EnumMember(Value = "wechatwork:service-provider:qrconnect")]
        WechatworkServiceProviderQrconnect,
        /// <summary>
        /// 新浪微博登录
        /// </summary>
        [EnumMember(Value = "weibo")]
        Weibo,
        /// <summary>
        /// GitHub 登录
        /// </summary>
        [EnumMember(Value = "github")]
        Github,
        /// <summary>
        /// Gitee 登录
        /// </summary>
        [EnumMember(Value = "gitee")]
        Gitee,
    }
}