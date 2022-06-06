using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
