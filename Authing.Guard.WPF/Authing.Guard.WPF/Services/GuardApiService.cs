using Authing.ApiClient.Domain.Model;
using Authing.ApiClient.Domain.Utils;
using Authing.ApiClient.Infrastructure.GraphQL;
using Authing.Guard.WPF.Infrastructures;
using Authing.Guard.WPF.Utils;
using Authing.Guard.WPF.Utils.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Authing.Guard.WPF.Services
{
    internal class GuardApiService
    {
        private IHttpService m_HttpService;

        private IJsonService m_JsonService;

        public GuardApiService()
        {
            m_JsonService = new JsonService();
            m_HttpService = new HttpService(m_JsonService);

            m_HttpService.SetHeader("x-authing-userpool-id", ConfigService.UserPoolId);
            m_HttpService.SetHeader("x-authing-app-id", ConfigService.AppId);
        }

        public async Task<GraphQLResponse<User>> PasswordLogin(string account, string password,bool autoRegister,Dictionary<string,string> customData, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(account))
            {
                throw new ArgumentException($"“{nameof(account)}”不能为 null 或空。", nameof(account));
            }

            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentException($"“{nameof(password)}”不能为 null 或空。", nameof(password));
            }

            string response = await m_HttpService.PostAsync(ConfigService.Host, "/api/v2/login/account", new Dictionary<string, string>() 
            {
                { "account",account},
                { "password",EncryptHelper.RsaEncryptWithPublic( password,ConfigService.PublicKey)},
                { "customData",m_JsonService.Serialize(customData)},
                { "autoRegister",autoRegister.ToString()}
                
            }, cancellationToken);

            GraphQLResponse<User> result = m_JsonService.Deserialize<GraphQLResponse<User>>(response);

            return result;
        }
    }
}
