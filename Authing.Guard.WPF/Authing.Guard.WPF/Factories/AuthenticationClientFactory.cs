using Authing.ApiClient.Domain.Client.Impl.AuthenticationClient;
using Authing.Guard.WPF.Services;
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
    }
}