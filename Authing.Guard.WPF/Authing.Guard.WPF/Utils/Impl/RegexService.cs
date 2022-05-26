using System.Text.RegularExpressions;

namespace Authing.Guard.WPF.Utils.Impl
{
    public class RegexService : IRegexService
    {
        public bool IsMail(string str)
        {
            Regex regex = new Regex(@"^(\w)+(\.\w)*@(\w)+((\.\w+)+)$");
            return regex.IsMatch(str);
        }

        public bool IsPhone(string str)
        {
            if (str.Length < 11)
            {
                return false;
            }
            //电信手机号码正则
            string dianxin = @"^1[3578][01379]\d{8}$";
            Regex regexDX = new Regex(dianxin);
            //联通手机号码正则
            string liantong = @"^1[34578][01256]\d{8}";
            Regex regexLT = new Regex(liantong);
            //移动手机号码正则
            string yidong = @"^(1[012345678]\d{8}|1[345678][012356789]\d{8})$";
            Regex regexYD = new Regex(yidong);
            if (regexDX.IsMatch(str) || regexLT.IsMatch(str) || regexYD.IsMatch(str))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool PasswordMatch(string str)
        {
            var middleLevel = new Regex(@"((?=.*\d)(?=.*\D)|(?=.*[a-zA-Z])(?=.*[^a-zA-Z]))(?!^.*[\u4E00-\u9FA5].*$).{6,}",
                                           RegexOptions.Multiline | RegexOptions.IgnorePatternWhitespace);

            return middleLevel.IsMatch(str);
        }
    }
}