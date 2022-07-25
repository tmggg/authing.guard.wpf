using Authing.ApiClient.Domain.Client.Impl.AuthenticationClient;
using Authing.ApiClient.Domain.Client.Impl.ManagementBaseClient;
using Authing.Guard.WPF.Services;
using Authing.Library.Domain.Client.Impl.AuthenticationClient;
using System;

namespace Authing.Guard.WPF.Factories
{
    public class AuthenticationClientFactory
    {
        public static AuthenticationClient GetAuthenticationClient()
        {
            return null;
        }
    }

    public class AuthClient
    {
        private static AuthenticationClient Client;

        private static readonly Lazy<AuthenticationClient> lazy =
            new Lazy<AuthenticationClient>(() =>
            {
                if (Client == null)
                {
                    Client = new AuthenticationClient(otp =>
                    {
                        otp.UserPoolId = ConfigService.UserPoolId;
                        otp.Secret = ConfigService.SecretId;
                        otp.AppId = ConfigService.AppId;
                        otp.Host = ConfigService.Host;
                    });
                }

                return Client;
            });

        public static AuthenticationClient Instance
        { get { return lazy.Value; } }

        private AuthClient()
        { }

        public static bool Init()
        {
            if (Client == null)
            {
                Client = new AuthenticationClient(otp =>
                {
                    otp.UserPoolId = ConfigService.UserPoolId;
                    otp.Secret = ConfigService.SecretId;
                    otp.AppId = ConfigService.AppId;
                    otp.Host = ConfigService.Host;
                });

                if (Client != null)
                {
                    return true;
                }
            }
            return true;
        }
    }

    public class AppManageClient
    {
        private static ManagementClient Client;

        private static readonly Lazy<ManagementClient> lazy =
            new Lazy<ManagementClient>(() =>
            {
                if (Client == null)
                {
                    Client = new ManagementClient(otp =>
                    {
                        otp.UserPoolId = ConfigService.UserPoolId;
                        otp.Secret = ConfigService.SecretId;
                        otp.Host = ConfigService.Host;
                    });
                }

                return Client;
            });

        public static ManagementClient Instance
        { get { return lazy.Value; } }

        private AppManageClient()
        { }

        public static bool Init()
        {
            if (Client == null)
            {
                Client = new ManagementClient(otp =>
                {
                    otp.UserPoolId = ConfigService.UserPoolId;
                    otp.Secret = ConfigService.SecretId;
                    otp.Host = ConfigService.Host;
                });
                if (Client != null)
                {
                    return true;
                }
            }
            return true;
        }
    }

    public class SocialAuthClient
    {
        private static SocialAuthenticationClient Client;

        private static readonly Lazy<SocialAuthenticationClient> lazy =
            new Lazy<SocialAuthenticationClient>(() =>
            {
                if (Client == null)
                {
                    Client = new SocialAuthenticationClient(otp =>
                    {
                        otp.UserPoolId = ConfigService.UserPoolId;
                        otp.Secret = ConfigService.SecretId;
                        otp.Host = ConfigService.Host;
                        otp.AppId = ConfigService.AppId;
                    });
                }

                return Client;
            });

        public static SocialAuthenticationClient Instance
        { get { return lazy.Value; } }

        private SocialAuthClient()
        { }

        public static bool Init()
        {
            if (Client == null)
            {
                Client = new SocialAuthenticationClient(otp =>
                {
                    otp.UserPoolId = ConfigService.UserPoolId;
                    otp.Secret = ConfigService.SecretId;
                    otp.Host = ConfigService.Host;
                    otp.AppId = ConfigService.AppId;
                });
                if (Client != null)
                {
                    return true;
                }
            }
            return true;
        }
    }

    public class QrCodeAuthClient
    {
        private static QrCodeAuthenticationClient Client;

        private static readonly Lazy<QrCodeAuthenticationClient> lazy =
            new Lazy<QrCodeAuthenticationClient>(() =>
            {
                if (Client == null)
                {
                    Client = new QrCodeAuthenticationClient(otp =>
                    {
                        otp.UserPoolId = ConfigService.UserPoolId;
                        otp.Secret = ConfigService.SecretId;
                        otp.Host = ConfigService.Host;
                        otp.AppId = ConfigService.AppId;
                    });
                }

                return Client;
            });

        public static QrCodeAuthenticationClient Instance
        { get { return lazy.Value; } }

        private QrCodeAuthClient()
        {
        }

        public static bool Init()
        {
            if (Client == null)
            {
                Client = new QrCodeAuthenticationClient(otp =>
                {
                    otp.UserPoolId = ConfigService.UserPoolId;
                    otp.Secret = ConfigService.SecretId;
                    otp.Host = ConfigService.Host;
                    otp.AppId = ConfigService.AppId;
                });
                if (Client != null)
                {
                    return true;
                }
            }
            return true;
        }
    }
}