using System.Globalization;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Data;
using Authing.Guard.WPF.Models;
using Authing.Guard.WPF.Utils;

namespace Authing.Guard.WPF.Infrastructures.Validations
{
    public class PhoneValidation : ValidationRuleBase
    {
        private Regex re = new Regex(@"^(13[0-9]|14[01456879]|15[0-35-9]|16[2567]|17[0-8]|18[0-9]|19[0-35-9])\d{8}$");

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string phone = "";
            var emptyCheck = base.Validate(value, cultureInfo);
            if (!emptyCheck.IsValid)
                return emptyCheck;
            if (value is string)
            {
                phone = value as string;
            }
            if (value is BindingExpression)
            {
                var bindingExpression = value as BindingExpression;
                phone = (bindingExpression.DataItem as InfoReplenish)?.Code;
            }
            if (value is null || ComparisonValue is null || ComparisonValue?.IsNessery == false)
            {
                return BuildResult(true, "");
            }
            if (re.IsMatch(phone))
            {
                return BuildResult(true);
            }
            return BuildResult(false, ResourceHelper.GetResource<string>("PhoneFormatError"));
        }
    }
}