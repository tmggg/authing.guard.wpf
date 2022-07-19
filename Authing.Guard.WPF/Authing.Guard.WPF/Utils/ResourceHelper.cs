using System;
using System.Windows;

namespace Authing.Guard.WPF.Utils
{
    /// <summary>资源帮助类</summary>
    public class ResourceHelper
    {
        private static ResourceDictionary _theme;

        /// <summary>获取内部资源</summary>
        /// <param name="key"></param>
        /// <returns></returns>
        internal static T GetResourceInternal<T>(string key) => GetTheme()[key] is T obj ? obj : default;

        /// <summary>获取程序资源</summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static T GetResource<T>(string key)
        {
            if (Application.Current.TryFindResource(key) is T resource)
            {
                return resource;
            }
            return default;
        }

        public static ResourceDictionary GetTheme() => _theme ?? (_theme = GetStandaloneTheme());

        public static ResourceDictionary GetStandaloneTheme() => new ResourceDictionary()
        {
            Source = new Uri(" pack://application:,,,/Authing.Guard.WPF;component/Styles/Generic.xaml")
        };

        public static ResourceDictionary GetLanguageDictionary(Authing.Guard.WPF.Enums.Lang lang)
        {
            ResourceDictionary dict = new ResourceDictionary();
            switch (lang)
            {
                case Enums.Lang.zhCn:
                    dict.Source = new Uri("pack://application:,,,/Authing.Guard.WPF;component/Lang/zh-CN.xaml", UriKind.Absolute);
                    break;
                case Enums.Lang.enUs:
                    dict.Source = new Uri("pack://application:,,,/Authing.Guard.WPF;component/Lang/en-US.xaml", UriKind.Absolute);
                    break;
                default:
                    dict.Source = new Uri("pack://application:,,,/Authing.Guard.WPF;component/Lang/zh-CN.xaml", UriKind.Absolute);
                    break;
            }
            return dict;
        }
    }
}