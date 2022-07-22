﻿using Authing.ApiClient.Domain.Client.Impl.AuthenticationClient;
using Authing.ApiClient.Domain.Model;
using Authing.Guard.WPF.Controls;
using Authing.Guard.WPF.Enums;
using Authing.Guard.WPF.Events;
using Authing.Guard.WPF.Events.EventAggreator;
using Authing.Guard.WPF.Factories;
using Authing.Guard.WPF.Models;
using Authing.Guard.WPF.Services;
using Authing.Guard.WPF.Utils;
using Authing.Guard.WPF.Utils.Extensions;
using Authing.Guard.WPF.Utils.Impl;
using CefSharp;
using CefSharp.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;

namespace Authing.Guard.WPF.Views.Classic.MainView
{
    /// <summary>
    /// MainView.xaml 的交互逻辑
    /// </summary>
    public partial class GuardMainView : BaseGuardControl, IEventListener
    {
        public static List<Agreement> Agreements { get; private set; }

        public static List<SocialConnection> SocialConnections { get; private set; }

        public static List<EnterpriseConnection> EnterpriseConnections { get; private set; }

        private IJsonService m_JsonService;

        public GuardMainView()
        {
            InitializeCefSharp();

            var dic = ResourceHelper.GetLanguageDictionary(Lang.zhCn);

            Application.Current.Resources.MergedDictionaries.Clear();


            Application.Current.Resources.MergedDictionaries.Add(dic);

            ResourceDictionary dict = new ResourceDictionary();
            dict.Source = new Uri("pack://application:,,,/Authing.Guard.WPF;component/Styles/IconResource.xaml", UriKind.Absolute);
            Application.Current.Resources.MergedDictionaries.Add(dict);

            InitializeComponent();

            m_JsonService = new JsonService();

            Loaded += MainView_Loaded;
            Unloaded += MainView_Unloaded;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static void InitializeCefSharp()
        {
            return;

            var settings = new CefSettings();

            // Set BrowserSubProcessPath based on app bitness at runtime
            settings.BrowserSubprocessPath = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase,
                                                   Environment.Is64BitProcess ? "x64" : "x86",
                                                   "CefSharp.BrowserSubprocess.exe");


            // Make sure you set performDependencyCheck false
            Cef.Initialize(settings, performDependencyCheck: false, browserProcessHandler: null);
        }

        // Will attempt to load missing assembly from either x86 or x64 subdir
        // Required by CefSharp to load the unmanaged dependencies when running using AnyCPU
        private static Assembly Resolver(object sender, ResolveEventArgs args)
        {
            if (args.Name.StartsWith("CefSharp"))
            {
                string assemblyName = args.Name.Split(new[] { ',' }, 2)[0] + ".dll";
                string archSpecificPath = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase,
                                                       Environment.Is64BitProcess ? "x64" : "x86",
                                                       assemblyName);

                return File.Exists(archSpecificPath)
                           ? Assembly.LoadFile(archSpecificPath)
                           : null;
            }

            return null;
        }



        private void MainView_Unloaded(object sender, RoutedEventArgs e)
        {
            RemoveEvent();
        }

        private async void MainView_Loaded(object sender, RoutedEventArgs e)
        {
            AddEvent();

            await InitConfig();

            content.Children.Add(new LoginMainView(Config));
        }

        private void AddEvent()
        {
            foreach (EventId item in Enum.GetValues(typeof(EventId)))
            {
                EventManagement.Instance.AddListener((int)item, this);
            }
        }

        private void RemoveEvent()
        {
            foreach (EventId item in Enum.GetValues(typeof(EventId)))
            {
                EventManagement.Instance.RemoveListener((int)item, this);
            }
        }

        private async Task InitConfig()
        {
            if (string.IsNullOrWhiteSpace(AppId))
            {
                throw new Exception("请输入 AppId");
            }
            if (string.IsNullOrWhiteSpace(UserPoolId))
            {
                throw new Exception("请输入 UserPoolId");
            }
            if (string.IsNullOrWhiteSpace(UserPoolSecret))
            {
                throw new Exception("请输入 Secret");
            }

            ConfigService.AppId = AppId;
            ConfigService.UserPoolId = UserPoolId;
            ConfigService.SecretId = UserPoolSecret;

            try
            {
                AuthClient.Init();
                AppManageClient.Init();


                var appInfo = await AppManageClient.Instance.Applications.FindByIdV2(AppId);
                //var app = await AppManageClient.Instance.Applications.FindById(AppId);
                if (appInfo != null)
                {
                    Config.Title = appInfo.Name;
                    Config.Logo = appInfo.Logo;

                    Config.LoginMethods = appInfo.LoginTabs.List.ToList().GetEnumByEnumMember<LoginMethods>();

                    Config.RegisterMethods = appInfo.RegisterTabs.List.ToList().GetEnumByEnumMember<RegisterMethods>();
                    Config.DefaultRegisterMethod = (RegisterMethods)Enum.Parse(typeof(RegisterMethods), appInfo.RegisterTabs.Default.FirstCharToUpper());
                    //Config.DefaultScences

                    SocialConnections = m_JsonService.Deserialize<List<SocialConnection>>(m_JsonService.Serialize(appInfo.SocialConnections));

                    Config.SocialConnections = SocialConnections.Select(p => p.Provider).ToList().GetEnumByEnumMember<SocialConnections>();

                    EnterpriseConnections = m_JsonService.Deserialize<List<EnterpriseConnection>>(m_JsonService.Serialize(appInfo.EcConnections));

                    Config.EnterpriseConnections = EnterpriseConnections;

                    Config.DefaultLoginMethod = (LoginMethods)Enum.Parse(typeof(LoginMethods), appInfo.LoginTabs.Default.FirstCharToUpper());
                    //Config.AutoRegister=appInfo.
                    Config.DisableRegister = appInfo.RegisterDisabled;
                    //Config.DisableResetPwd=appInfo.p
                    //Config.IsSSO = m_JsonService.Deserialize<bool>( appInfo.SsoPageCustomizationSettings.ToString());
                    Config.AppHost = appInfo.RequestHostname;
                    //Config.Lang
                    Agreements = m_JsonService.Deserialize<List<Agreement>>(m_JsonService.Serialize(appInfo.Agreements));


                }

                EventManagement.Instance.Dispatch((int)EventId.Load, EventArgs<AuthenticationClient>.CreateEventArgs(AuthClient.Instance));
            }
            catch (Exception exp)
            {
                EventManagement.Instance.Dispatch((int)EventId.LoadError, EventArgs<string>.CreateEventArgs(exp.Message));
            }
        }


        public void HandleEvent(int eventId, IEventArgs args)
        {
            if (CheckAccess())
            {
                HandleWithEvents(eventId, args);
            }
            else
            {
                Dispatcher.BeginInvoke(new Action(() =>
                {
                    HandleWithEvents(eventId, args);
                }));
            }
        }

        private void HandleWithEvents(int eventId, IEventArgs args)
        {
            switch (eventId)
            {
                case (int)EventId.Load:
                    Config.Load?.Invoke(AuthClient.Instance);
                    break;

                case (int)EventId.LoadError:
                    Config.LoadError?.Invoke(args.GetValue<string>());
                    break;

                case (int)EventId.Login:
                    Config.Login?.Invoke(args.GetValue<User>(), AuthClient.Instance);
                    break;

                case (int)EventId.LoginError:
                    Config.LoginError?.Invoke(args.GetValue<string>());
                    break;

                case (int)EventId.Register:
                    Config.Register?.Invoke(args.GetValue<User>(), AuthClient.Instance);
                    break;

                case (int)EventId.RegisterError:
                    Config.RegisterError?.Invoke(args.GetValue<string>());
                    break;

                case (int)EventId.PwdEmailSend:
                    Config.PwdEmailSend?.Invoke();
                    break;

                case (int)EventId.PwdEmailSendError:
                    Config.PwdEmailSendError?.Invoke(args.GetValue<string>());
                    break;

                case (int)EventId.PwdPhoneSend:
                    Config.PwdPhoneSend?.Invoke();
                    break;

                case (int)EventId.PwdPhoneSendError:
                    Config.PwdPhoneSendError?.Invoke(args.GetValue<string>());
                    break;

                case (int)EventId.PwdReset:
                    Config.PwdReset?.Invoke();
                    break;

                case (int)EventId.PwdResetError:
                    Config.PwdResetError?.Invoke(args.GetValue<string>());
                    break;

                case (int)EventId.LoginTabChange:
                    Config.LoginTabChange?.Invoke(args.GetValue<string>());
                    break;

                case (int)EventId.RegisterTabChange:
                    Config.RegisterTabChange?.Invoke(args.GetValue<string>());
                    break;

                case (int)EventId.RegisterInfoCompleted:
                    Config.RegisterInfoCompleted?.Invoke(args.GetValue<User>(), AuthClient.Instance);
                    break;

                case (int)EventId.RegisterInfoCompletedError:
                    Config.RegisterInfoCompletedError?.Invoke(args.GetValue<User>(), AuthClient.Instance);
                    break;
                case (int)EventId.ToResetPassword:
                    ToResetPasswordView();
                    break;
                case (int)EventId.ToRegister:
                    ToRegisterView();
                    break;
                case (int)EventId.ToLogin:
                    ToLoginView();
                    break;
                case (int)EventId.ToFeedback:
                    ToFeedbackView();
                    break;


                default: break;
            }
        }

        private void ToResetPasswordView()
        {
            content.Children.Clear();
            content.Children.Add(new ResetPasswordMainView(Config));

            bottomView.Visibility = Visibility.Hidden;
        }

        private void ToRegisterView()
        {
            content.Children.Clear();
            content.Children.Add(new RegisterMainView(Config));

            bottomView.Visibility = Visibility.Visible;
        }

        private void ToLoginView()
        {
            content.Children.Clear();
            content.Children.Add(new LoginMainView(Config));

            bottomView.Visibility = Visibility.Visible;
        }

        private void ToFeedbackView()
        {

        }
    }
}