using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authing.Guard.WPF.Utils
{
    public interface IRegexService
    {
        /// <summary>
        /// 判断输入的字符串是否是邮箱
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        bool IsMail(string str);

        /// <summary>
        /// 判断输入的字符串是否是手机号
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        bool IsPhone(string str);

        /// <summary>
        /// 密码是否复合标准
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        bool PasswordMatch(string str);
        
    }
}
