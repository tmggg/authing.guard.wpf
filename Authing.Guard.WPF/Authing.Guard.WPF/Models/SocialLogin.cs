using System.ComponentModel;
using System.Windows.Media;

namespace Authing.Guard.WPF.Models
{
    public class SocialLogin : INotifyPropertyChanged
    {
        public string LoginUrl { get; }

        public string AuthenticationUrl { get; }

        public SolidColorBrush FColor { get; }
        public Geometry Logo { get; }

        public SocialLogin(string loginUrl, string authenticationUrl,SolidColorBrush fColor, Geometry logo)
        {
            LoginUrl = loginUrl;
            FColor = fColor;
            Logo = logo;
            AuthenticationUrl = authenticationUrl;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}