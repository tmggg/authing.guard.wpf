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
        /// <summary>
        /// 跳转到登录界面
        /// </summary>
        ToLogin,
        /// <summary>
        /// 跳转到忘记密码界面
        /// </summary>
        ToResetPassword,
        /// <summary>
        /// 跳转到注册界面
        /// </summary>
        ToRegister,
        /// <summary>
        /// 跳转到问题反馈界面
        /// </summary>
        ToFeedback,


        /// <summary>
        /// 是否同意登录协议
        /// </summary>
        PasswordLoginAgreementCheck,
        /// <summary>
        /// 检查同意登录协议完成
        /// </summary>
        PasswordLoginLoginAgreementCheckFinish,
        /// <summary>
        /// 是否同意登录协议
        /// </summary>
        SMSCodeLoginLoginAgreementCheck,
        /// <summary>
        /// 检查同意登录协议完成
        /// </summary>
        SMSCodeLoginLoginLoginAgreementCheckFinish,
        /// <summary>
        /// 是否同意登录协议
        /// </summary>
        ScanCodeLoginLoginAgreementCheck,
        /// <summary>
        /// 检查同意登录协议完成
        /// </summary>
        ScanCodeLoginLoginLoginAgreementCheckFinish,
        /// <summary>
        /// 是否同意登录协议
        /// </summary>
        ADLoginLoginAgreementCheck,
        /// <summary>
        /// 检查同意登录协议完成
        /// </summary>
        ADLoginLoginLoginAgreementCheckFinish,
        /// <summary>
        /// 是否同意登录协议
        /// </summary>
        WeChatLoginLoginAgreementCheck,
        /// <summary>
        /// 检查同意登录协议完成
        /// </summary>
        WeChatLoginLoginLoginAgreementCheckFinish,
        /// <summary>
        /// 是否同意登录协议
        /// </summary>
        WeChatOfficalLoginLoginAgreementCheck,
        /// <summary>
        /// 检查同意登录协议完成
        /// </summary>
        WeChatOfficalLoginLoginLoginAgreementCheckFinish,
        /// <summary>
        /// 是否同意注册协议
        /// </summary>
        MailRegisterAgreementCheck,
        /// <summary>
        /// 检查同意注册协议完成
        /// </summary>
        MailRegisterAgreementCheckFinish,
        /// <summary>
        /// 是否同意注册协议
        /// </summary>
        PhoneRegisterAgreementCheck,
        /// <summary>
        /// 检查同意注册协议完成
        /// </summary>
        PhoneRegisterAgreementCheckFinish


    }
}
