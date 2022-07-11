using Authing.Guard.WPF.Models;
using System.Windows;
using System.Windows.Controls;

namespace Authing.Guard.WPF.Controls
{
    public class BaseGuardControl : UserControl
    {
        public BaseGuardControl()
        { }

        /// <summary>
        /// 在 Console 中配置应用 ID
        /// </summary>
        public string AppId
        {
            get
            {
                return (string)GetValue(AppIdProperty);
            }
            set
            {
                SetValue(AppIdProperty, value);
            }
        }

        public static DependencyProperty AppIdProperty =
             DependencyProperty.Register(nameof(AppId), typeof(string), typeof(BaseGuardControl), new PropertyMetadata(string.Empty));

        /// <summary>
        /// 在 Console 中配置用户池 ID
        /// </summary>
        public string UserPoolId
        {
            get
            {
                return (string)GetValue(UserPoolIdProperty);
            }
            set
            {
                SetValue(UserPoolIdProperty, value);
            }
        }

        public static DependencyProperty UserPoolIdProperty =
             DependencyProperty.Register(nameof(UserPoolId), typeof(string), typeof(BaseGuardControl), new PropertyMetadata(string.Empty));

        /// <summary>
        /// 在 Console 中配置用户池密钥
        /// </summary>
        public string UserPoolSecret
        {
            get
            {
                return (string)GetValue(UserPoolSecretProperty);
            }
            set
            {
                SetValue(UserPoolSecretProperty, value);
            }
        }

        public static DependencyProperty UserPoolSecretProperty =
             DependencyProperty.Register(nameof(UserPoolSecret), typeof(string), typeof(BaseGuardControl), new PropertyMetadata(string.Empty));

        /// <summary>
        /// 租户 ID 使用租户相关功能时进行使用
        /// </summary>
        public string TenentId
        {
            get
            {
                return (string)GetValue(TenantIdProperty);
            }
            set
            {
                SetValue(TenantIdProperty, value);
            }
        }

        public static DependencyProperty TenantIdProperty =
            DependencyProperty.Register(nameof(TenentId), typeof(string), typeof(BaseGuardControl), new PropertyMetadata(string.Empty));

        /// <summary>
        /// 高级配置
        /// </summary>
        public GuardConfig Config
        {
            get
            {
                return (GuardConfig)GetValue(ConfigProperty);
            }
            set
            {
                SetValue(ConfigProperty, value);
            }
        }

        public static DependencyProperty ConfigProperty =
            DependencyProperty.Register(nameof(Config), typeof(GuardConfig), typeof(BaseGuardControl), new PropertyMetadata(new GuardConfig()));
    }
}