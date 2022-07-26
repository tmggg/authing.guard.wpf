using Authing.Guard.WPF.Enums;
using System.ComponentModel;
using System.Windows.Media;

namespace Authing.Guard.WPF.Models
{
    public class SocialLogin 
    {
        public string LoginUrl { get; }

        public string AuthenticationUrl { get; }

        public SolidColorBrush FColor { get; }

        public IconType IconType { get; }

        public SocialLogin(string loginUrl, string authenticationUrl,SolidColorBrush fColor, IconType iconType)
        {
            LoginUrl = loginUrl;
            FColor = fColor;
            AuthenticationUrl = authenticationUrl;
            IconType= iconType;
        }

    }
}