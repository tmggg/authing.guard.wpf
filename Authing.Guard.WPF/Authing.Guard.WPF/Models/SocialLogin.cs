using System.ComponentModel;
using System.Windows.Media;

namespace Authing.Guard.WPF.Models
{
    public class SocialLogin : INotifyPropertyChanged
    {
        public string LoginUrl { get; }
        public SolidColorBrush FColor { get; }
        public Geometry Logo { get; }

        public SocialLogin(string loginUrl, SolidColorBrush fColor, Geometry logo)
        {
            LoginUrl = loginUrl;
            FColor = fColor;
            Logo = logo;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}