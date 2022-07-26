using System;
using System.Threading;

namespace Authing.Guard.WPF.Services
{
    public class ConfigService
    {
        public static string UserPoolId { get; set; }
        public static string SecretId { get; set; }
        public static string AppId { get; set; }
        public static string Host { get; set; }

        public static string PublicKey = @"-----BEGIN PUBLIC KEY-----
MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQC4xKeUgQ+Aoz7TLfAfs9+paePb
5KIofVthEopwrXFkp8OCeocaTHt9ICjTT2QeJh6cZaDaArfZ873GPUn00eOIZ7Ae
+TiA2BKHbCvloW3w5Lnqm70iSsUi5Fmu9/2+68GZRH9L7Mlh8cFksCicW2Y2W2uM
GKl64GDcIq3au+aqJQIDAQAB
-----END PUBLIC KEY-----";

        public static CancellationTokenSource CreateCancellationTokenSource()
        {
            const int SECONDS = 10;
            return new CancellationTokenSource(TimeSpan.FromSeconds(SECONDS));
        }
    }
}