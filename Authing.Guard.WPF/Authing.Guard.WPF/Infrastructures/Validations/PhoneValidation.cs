using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using Authing.Guard.WPF.Utils;

namespace Authing.Guard.WPF.Infrastructures.Validations
{
    public class PhoneValidation : ValidationRuleBase
    {
        private Regex re = new Regex(@"^(13[0-9]|14[01456879]|15[0-35-9]|16[2567]|17[0-8]|18[0-9]|19[0-35-9])\d{8}$");

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var emptyCheck = base.Validate(value, cultureInfo);
            if (!emptyCheck.IsValid)
                return emptyCheck;
            if (re.IsMatch(value as string ?? string.Empty))
            {
                return BuildResult(true);
            }
            return BuildResult(false, ResourceHelper.GetResource<string>("PhoneFormatError"));
        }
    }
}