using Authing.Guard.WPF.Annotations;
using Authing.Guard.WPF.Utils;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Markup;
using Authing.Guard.WPF.Models;

namespace Authing.Guard.WPF.Infrastructures.Validations
{
    [ContentProperty("ComparisonValue")]
    public abstract class ValidationRuleBase : ValidationRule
    {
        public ComparisonValue ComparisonValue { get; set; }
        public string Property { get; set; }
        protected string ErrorMessage { get; set; } = "This field have error";

        protected ValidationResult BuildResult(bool isVaid, [CanBeNull] string errorMessage = null) => new ValidationResult(isVaid, errorMessage);

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (ComparisonValue?.IsNessery == false || ComparisonValue == null)
            {
                return BuildResult(true, "");
            }
            if (value is BindingExpression expression)
            {
                var info = expression.DataItem as InfoReplenish;

                if (string.IsNullOrWhiteSpace(info?.Data))
                    return BuildResult(false, ComparisonValue?.DataName + " " + ResourceHelper.GetResource<string>("EmptyError"));
                else
                    return BuildResult(true, "");
            }
            if (value is string s)
            {
                if (string.IsNullOrWhiteSpace(s))
                {
                    return BuildResult(false, ComparisonValue?.DataName + " " + ResourceHelper.GetResource<string>("EmptyError"));
                }
            }
            else
                return BuildResult(false, ErrorMessage);
            return BuildResult(true, "");
        }
    }
}