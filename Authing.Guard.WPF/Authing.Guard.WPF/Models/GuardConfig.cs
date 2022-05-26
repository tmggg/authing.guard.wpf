using Authing.ApiClient.Domain.Client.Impl.AuthenticationClient;
using Authing.ApiClient.Domain.Model;
using Authing.Guard.WPF.Enums;
using System;
using System.Collections.Generic;

namespace Authing.Guard.WPF.Models
{
    public class GuardConfig
    {
        #region 属性

        /// <summary>
        /// 产品名称
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 产品 Logo
        /// </summary>
        public string Logo { get; set; }

        /// <summary>
        /// 需要使用的普通登录(包括 LDAP)方式列表
        /// </summary>
        public List<LoginMethods> LoginMethods { get; set; }

        /// <summary>
        /// 需要使用的注册方式
        /// </summary>
        public List<RegisterMethods> RegisterMethods { get; set; }

        /// <summary>
        /// 默认展示的注册方式
        /// </summary>
        public RegisterMethods DefaultRegisterMethod { get; set; }

        /// <summary>
        /// 打开组件时展示的界面
        /// </summary>
        public GuardScenes DefaultScences { get; set; }

        /// <summary>
        /// 需要使用的社会化登录列表
        /// </summary>
        public List<SocialConnections> SocialConnections { get; set; }

        /// <summary>
        /// 默认显示的登录方式。可选值为 LoginMethod 中的某一项
        /// </summary>
        public LoginMethods DefaultLoginMethod { get; set; }

        /// <summary>
        /// 是否将注册和登录合并，合并后如果用户不存在将自动注册
        /// </summary>
        public bool AutoRegister { get; set; }

        /// <summary>
        /// 是否禁止注册，禁止的话会隐藏 [注册] 入口
        /// </summary>
        public bool DisableRegister { get; set; }

        /// <summary>
        /// 是否禁止重置密码，禁止的话会隐藏 [忘记密码] 入口
        /// </summary>
        public bool DisableResetPwd { get; set; }

        /// <summary>
        /// 是否是单点登录
        /// </summary>
        public bool IsSSO { get; set; }

        /// <summary>
        /// 是否是单点登录
        /// </summary>
        public string AppHost { get; set; }

        /// <summary>
        /// 使用语言
        /// </summary>
        public Lang Lang { get; set; }

        /// <summary>
        /// 语言环境配置
        /// </summary>
        public LocalesConfig LocalesConfig { get; set; }

        /// <summary>
        /// 私有部署时的 API 请求地址
        /// </summary>
        public string Host { get; set; }

        #endregion 属性

        #region 事件

        /// <summary>
        /// Authing AppId 验证通过，加载完成。AuthenticationClient 对象，可直接操作 login， register;
        /// </summary>
        public Action<AuthenticationClient> Load;

        /// <summary>
        /// Authing AppId 验证失败，加载失败
        /// </summary>
        public Action<string> LoadError;

        /// <summary>
        /// 用户登录成功。user: 用户信息；AuthenticationClient 对象，可直接操作 login， register;
        /// </summary>
        public Action<User, AuthenticationClient> Login;

        /// <summary>
        /// 用户登录失败。错误信息，包含字段缺失／非法或服务器错误等信息
        /// </summary>
        public Action<string> LoginError;

        /// <summary>
        /// 用户注册成功。user: 用户信息；AuthenticationClient 对象，可直接操作 login， register;
        /// </summary>
        public Action<User, AuthenticationClient> Register;

        /// <summary>
        /// 用户注册失败。错误信息，包含字段缺失／非法或服务器错误等信息
        /// </summary>
        public Action<string> RegisterError;

        /// <summary>
        /// 忘记密码邮件发送成功
        /// </summary>
        public Action PwdEmailSend;

        /// <summary>
        /// 忘记密码邮件发送失败。Error :错误信息
        /// </summary>
        public Action<string> PwdEmailSendError;

        /// <summary>
        /// 忘记密码手机验证码发送成功
        /// </summary>
        public Action PwdPhoneSend;

        /// <summary>
        /// 忘记密码手机验证码发送失败。Error ：错误信息
        /// </summary>
        public Action<string> PwdPhoneSendError;

        /// <summary>
        /// 重置密码成功
        /// </summary>
        public Action PwdReset;

        /// <summary>
        /// 重置密码失败。Error ：错误信息
        /// </summary>
        public Action<string> PwdResetError;

        /// <summary>
        /// 登录 Tab 切换事件；切换后的 Tab
        /// </summary>
        public Action<string> LoginTabChange;

        /// <summary>
        /// 注册 Tab 切换事件；string：切换后的 Tab
        /// </summary>
        public Action<string> RegisterTabChange;

        /// <summary>
        /// 注册补充成功事件.user: 用户信息.AuthenticationClient 对象，可直接操作 login， register;
        /// </summary>
        public Action<User, AuthenticationClient> RegisterInfoCompleted;

        /// <summary>
        /// 注册补充失败事件.user: 用户信息.AuthenticationClient 对象，可直接操作 login， register;
        /// </summary>
        public Action<User, AuthenticationClient> RegisterInfoCompletedError;

        #endregion 事件
    }
}