using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;
using Authing.Guard.WPF.Models;
using Authing.Guard.WPF.Utils;

namespace Authing.Guard.WPF.Infrastructures.Validations
{
    public class MailValidation : ValidationRuleBase
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string valueAsString = "";
            var emptyCheck = base.Validate(value, cultureInfo);
            if (!emptyCheck.IsValid)
                return emptyCheck;
            if (value is string s)
            {
                valueAsString = s;
            }
            if (value is BindingExpression)
            {
                var bindingExpression = value as BindingExpression;
                valueAsString = (bindingExpression.DataItem as InfoReplenish).Code;
            }
            int index = valueAsString.IndexOf('@');
            if (ComparisonValue?.IsNessery == false || ComparisonValue == null || value == null)
            {
                return BuildResult(true, "");
            }
            if (index > 0 && index != valueAsString.Length - 1 && index == valueAsString.LastIndexOf('@'))
            {
                return BuildResult(true, "");
            }
            return BuildResult(false, ResourceHelper.GetResource<string>("MailFormatError"));
        }
    }
}