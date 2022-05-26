using System.Windows.Input;

namespace Authing.Guard.WPF.Commons
{
    public static class AuthingGuardCommands
    {
        /// <summary>
        /// 刷新二维码命令
        /// </summary>
        public static RoutedCommand RefreshQrCodeCommand { get; } = new RoutedCommand(nameof(AuthingGuardCommands), typeof(AuthingGuardCommands));

        /// <summary>
        /// 切换语言命令
        /// </summary>
        public static RoutedCommand LanguagechangedCommand { get; } = new RoutedCommand(nameof(AuthingGuardCommands), typeof(AuthingGuardCommands));
    }
}