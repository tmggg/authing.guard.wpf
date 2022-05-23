using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Authing.Guard.WPF.Services
{
    public class RegexService
    {
        public static bool IsMobile(string mobile)
        {
            if (string.IsNullOrEmpty(mobile))
            {
                return false;
            }

            return Regex.IsMatch(mobile, @"^(1)\d{10}$");
        }
    }
}
