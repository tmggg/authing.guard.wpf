using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authing.Guard.WPF.Services
{
    public class ConfigService
    {
        public static string UserPoolId { get; set; }
        public static string SecretId { get; set; }
        public static string AppId { get; set; }
        public static string Host { get; set; }
    }
}
