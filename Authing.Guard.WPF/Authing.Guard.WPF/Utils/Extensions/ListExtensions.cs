using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authing.Guard.WPF.Utils.Extensions
{
    public static class ListExtensions
    {
        public static List<TEnum> GetEnumByEnumMember<TEnum>(this List<string> list) where TEnum : Enum
        {
            List<TEnum> enums = new List<TEnum>();

            foreach (var item in list)
            {
                enums.Add(item.GetEnumByEnumMember<TEnum>());
            }

            return enums;
        }
    }
}
