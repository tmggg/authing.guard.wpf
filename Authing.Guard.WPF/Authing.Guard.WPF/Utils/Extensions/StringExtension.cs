using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Authing.Guard.WPF.Enums;
using Authing.Guard.WPF.Infrastructures.Validations;

namespace Authing.Guard.WPF.Utils.Extensions
{
    public static class StringExtension
    {
        public static string FirstCharToUpper(this string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentNullException();
            }

            return input.First().ToString().ToUpper() + input.Substring(1);
        }

        public static bool CompareWith(this string source, string target)
        {
            return string.CompareOrdinal(source, target) == 0;
        }

        public static ValidationResult ValidationData(this string data, ValidationType type = ValidationType.Empty)
        {
            ValidationRule rule = null;
            ValidationResult res = null;
            switch (type)
            {
                case ValidationType.Empty:
                    rule = new EmptyValidation();
                    res = rule.Validate(data, null);
                    break;

                case ValidationType.Phone:
                    rule = new PhoneValidation();
                    res = rule.Validate(data, null);

                    break;

                case ValidationType.Email:
                    rule = new MailValidation();
                    res = rule.Validate(data, null);

                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }

            return res;
        }

        public static TEnum GetEnumByEnumMember<TEnum>(this string value) where TEnum : Enum
        {
            foreach (var item in typeof(TEnum).GetFields())
            {
                if (Attribute.GetCustomAttribute(item, typeof(EnumMemberAttribute)) is EnumMemberAttribute attribute)
                {
                    if (string.Equals(attribute.Value, value))
                        return (TEnum)item.GetValue(null);
                }
            }

            throw new Exception("");
        }
    }
}