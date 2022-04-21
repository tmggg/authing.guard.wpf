using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authing.Guard.WPF.Enums
{
    public enum SocialConnections
    {
        /// <summary>
        /// QQ 登录
        /// </summary>
        [Description("qq")]
        Qq,
        /// <summary>
        /// 新浪微博登录
        /// </summary>
        [Description("weibo")]
        Weibo,
        /// <summary>
        /// GitHub 登录
        /// </summary>
        [Description("github")]
        Github,
        /// <summary>
        /// Google 账号登录
        /// </summary>
        [Description("google")]
        Google,
        /// <summary>
        /// 微信 PC 端登录
        /// </summary>
        [Description("wechat:pc")]
        WxPc,
        /// <summary>
        /// 钉钉登录
        /// </summary>
        [Description("dingtalk")]
        Dingtalk,
        /// <summary>
        /// 企业微信二维码登录
        /// </summary>
        [Description("wechatwork:corp:qrconnect")]
        WxWCorpQr,
        /// <summary>
        /// 企业微信第三方应用扫码授权登录
        /// </summary>
        [Description("wechatwork:service-provider:qrconnect")]
        WxWSPQr,
        /// <summary>
        /// 企业微信第三方应用网页授权登录
        /// </summary>
        [Description("wechatwork:service-provider:authorization")]
        WxWSPAuth
    }
}
