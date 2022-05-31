using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authing.Guard.WPF.Events
{
    public enum EventId
    {
        /// <summary>
        /// Authing AppId 验证通过，加载完成。
        /// </summary>
        Load,
        /// <summary>
        /// Authing AppId 验证失败，加载失败
        /// </summary>
        LoadError,
        /// <summary>
        /// 用户登录成功
        /// </summary>
        Login,
        /// <summary>
        /// 用户登录失败
        /// </summary>
        LoginError,
        /// <summary>
        /// 用户注册成功
        /// </summary>
        Register,
        /// <summary>
        /// 用户注册失败
        /// </summary>
        RegisterError,
        /// <summary>
        /// 忘记密码邮件发送成功
        /// </summary>
        PwdEmailSend,
        /// <summary>
        /// 忘记密码邮件发送失败
        /// </summary>
        PwdEmailSendError,
        /// <summary>
        /// 忘记密码手机验证码发送成功
        /// </summary>
        PwdPhoneSend,
        /// <summary>
        /// 忘记密码手机验证码发送失败
        /// </summary>
        PwdPhoneSendError,
        /// <summary>
        /// 重置密码成功
        /// </summary>
        PwdReset,
        /// <summary>
        /// 重置密码失败
        /// </summary>
        PwdResetError,
        /// <summary>
        /// 登录 Tab 切换事件
        /// </summary>
        LoginTabChange,
        /// <summary>
        /// 注册 Tab 切换事件
        /// </summary>
        RegisterTabChange,
        /// <summary>
        /// 注册补充成功事件
        /// </summary>
        RegisterInfoCompleted,
        /// <summary>
        /// 注册补充失败事件
        /// </summary>
        RegisterInfoCompletedError,
        /// <summary>
        /// 语言选择改变
        /// </summary>
        LanguageChanged,

    }
}
