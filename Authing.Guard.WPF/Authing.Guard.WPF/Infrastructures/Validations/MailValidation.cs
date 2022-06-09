using System.Globalization;
using System.Windows.Controls;
using Authing.Guard.WPF.Utils;

namespace Authing.Guard.WPF.Infrastructures.Validations
{
    public class MailValidation : ValidationRuleBase
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var emptyCheck = base.Validate(value, cultureInfo);
            if (!emptyCheck.IsValid)
                return emptyCheck;
            var valueAsString = value as string;
            int index = valueAsString.IndexOf('@');
            if (index > 0 && index != valueAsString.Length - 1 && index == valueAsString.LastIndexOf('@'))
            {
                return BuildResult(true, "");
            }
            return BuildResult(false, ResourceHelper.GetResource<string>("MailFormatError"));
        }
    }
}