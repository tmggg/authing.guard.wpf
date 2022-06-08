using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using Authing.Guard.WPF.Annotations;
using Authing.Guard.WPF.Utils;

namespace Authing.Guard.WPF.Infrastructures.Validations
{
    public abstract class ValidationRuleBase : ValidationRule
    {
        public string Property { get; set; }
        protected string ErrorMessage { get; set; } = "This field have error";

        protected ValidationResult BuildResult(bool error, [CanBeNull] string errorMessage = null) => new ValidationResult(error, errorMessage);

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value is null)
            {
                return BuildResult(true, "");
            }
            if (value is string)
            {
                if (string.IsNullOrWhiteSpace(value as string))
                {
                    return BuildResult(false, ResourceHelper.GetResource<string>("EmptyError"));
                }
            }
            else
            {
                return BuildResult(false, ErrorMessage);
            }
            return BuildResult(true, "");
        }
    }
}