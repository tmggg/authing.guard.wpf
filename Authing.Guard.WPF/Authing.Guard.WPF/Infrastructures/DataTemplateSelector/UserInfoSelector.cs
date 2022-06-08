using System.Windows;
using Authing.Guard.WPF.Enums;
using Authing.Guard.WPF.Models;

namespace Authing.Guard.WPF.Infrastructures.DataTemplateSelector
{
    public class UserInfoSelector : System.Windows.Controls.DataTemplateSelector
    {
        public DataTemplate InfoWithTextBox { get; set; }
        public DataTemplate InfoWithComboBox { get; set; }
        public DataTemplate PhoneReplenish { get; set; }
        public DataTemplate MailReplenish { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item != null)
            {
                var data = (InfoReplenish)item;
                if (data.InfoType == InfoType.Phone)
                {
                    return PhoneReplenish;
                }

                if (data.InfoType == InfoType.Mail)
                {
                    return MailReplenish;
                }

                if (data.HaveItem)
                {
                    return InfoWithComboBox;
                }
            }
            return InfoWithTextBox;
        }
    }
}