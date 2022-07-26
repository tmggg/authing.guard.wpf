using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Authing.Guard.WPF.Utils.Impl
{
   internal sealed class HttpService : IHttpService
    {
        private const string HttpClientName = "SANLIAN";
        private readonly IServiceProvider m_ServiceProvider;
        private readonly IJsonService m_JsonService;
        private string m_BearerToken = string.Empty;
        private Dictionary<string,string> m_HeaderDic;

        public HttpService(IJsonService jsonService)
        {
            m_JsonService = jsonService;

            ServiceCollection sc = new ServiceCollection();
            sc.AddHttpClient(HttpClientName, r => { }).ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler()
            {
                UseProxy = false, //关闭代理
                ServerCertificateCustomValidationCallback = (sender, certificate, chain, errors) => true,
            });

            m_ServiceProvider = sc.BuildServiceProvider();
            m_HeaderDic = new Dictionary<string, string>();
        }

        public async Task<string> GetAsync(string baseUrl, string apiPath, Dictionary<string, string> param, CancellationToken cancellationToken, string bearerToken = null)
        {
            try
            {
                HttpClient httpClient = FactoryBuild(baseUrl);
                string finalUrl = UrlCombine(baseUrl, apiPath, param);
                using HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, finalUrl);

                if (!string.IsNullOrWhiteSpace(bearerToken))
                {
                    request.Headers.Add("Authorization", $"Bearer {bearerToken}");
                }
                else if (!string.IsNullOrWhiteSpace(m_BearerToken))
                {
                    request.Headers.Add("Authorization", $"Bearer {m_BearerToken}");
                }

                foreach (var item in m_HeaderDic)
                {
                    request.Headers.Add(item.Key, item.Value);
                }

                using HttpResponseMessage response = await httpClient.SendAsync(request, cancellationToken).ConfigureAwait(false);
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"代码：{(int)response.StatusCode}");
                }

                return await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            }
            catch (TaskCanceledException)
            {
                throw new Exception("网络连接失败");
            }
        }

        public async Task<string> PostAsync(string baseUrl, string apiPath, Dictionary<string, string> param, CancellationToken cancellationToken, string bearerToken = null)
        {
            try
            {
                string s = m_JsonService.Serialize(param);

                HttpClient httpClient = FactoryBuild(baseUrl);
                string url = UrlCombine(baseUrl, apiPath, null);
                using HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url)
                {
                    Content = new StringContent(s, Encoding.UTF8, "application/json"),
                };

                if (!string.IsNullOrWhiteSpace(bearerToken))
                {
                    request.Headers.Add("Authorization", $"Bearer {bearerToken}");
                }
                else if (!string.IsNullOrWhiteSpace(m_BearerToken))
                {
                    request.Headers.Add("Authorization", $"Bearer {m_BearerToken}");
                }

                foreach (var item in m_HeaderDic)
                {
                    request.Headers.Add(item.Key, item.Value);
                }

                using HttpResponseMessage response = await httpClient.SendAsync(request, cancellationToken).ConfigureAwait(false);
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"代码：{(int)response.StatusCode}");
                }

                return await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            }
            catch (TaskCanceledException)
            {
                throw new Exception("网络连接失败");
            }
        }

        public async Task<string> PostAsync(string baseUrl, string apiPath, string jsonParam, CancellationToken cancellationToken, string bearerToken = null)
        {
            try
            {
                HttpClient httpClient = FactoryBuild(baseUrl);
                string url = UrlCombine(baseUrl, apiPath, null);
                using HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url)
                {
                    Content = new StringContent(jsonParam, Encoding.UTF8, "application/json"),
                };

                if (!string.IsNullOrWhiteSpace(bearerToken))
                {
                    request.Headers.Add("Authorization", $"Bearer {bearerToken}");
                }
                else if (!string.IsNullOrWhiteSpace(m_BearerToken))
                {
                    request.Headers.Add("Authorization", $"Bearer {m_BearerToken}");
                }

                foreach (var item in m_HeaderDic)
                {
                    request.Headers.Add(item.Key, item.Value);
                }

                using HttpResponseMessage response = await httpClient.SendAsync(request, cancellationToken).ConfigureAwait(false);
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"代码：{(int)response.StatusCode}");
                }

                return await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            }
            catch (TaskCanceledException)
            {
                throw new Exception("网络连接失败");
            }
        }

        public async Task<string> PutAsync(string baseUrl, string apiPath, string jsonParam, CancellationToken cancellationToken, string bearerToken = null)
        {
            try
            {
                HttpClient httpClient = FactoryBuild(baseUrl);
                string url = UrlCombine(baseUrl, apiPath, null);
                using HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Put, url)
                {
                    Content = new StringContent(jsonParam, Encoding.UTF8, "application/json"),
                };

                if (!string.IsNullOrWhiteSpace(bearerToken))
                {
                    request.Headers.Add("Authorization", $"Bearer {bearerToken}");
                }
                else if (!string.IsNullOrWhiteSpace(m_BearerToken))
                {
                    request.Headers.Add("Authorization", $"Bearer {m_BearerToken}");
                }

                foreach (var item in m_HeaderDic)
                {
                    request.Headers.Add(item.Key, item.Value);
                }

                using HttpResponseMessage response = await httpClient.SendAsync(request, cancellationToken).ConfigureAwait(false);
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"代码：{(int)response.StatusCode}");
                }

                return await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            }
            catch (TaskCanceledException)
            {
                throw new Exception("网络连接失败");
            }
        }

        public async Task<string> DeleteAsync(string baseUrl, string apiPath, string jsonParam, CancellationToken cancellationToken, string bearerToken = null)
        {
            try
            {
                HttpClient httpClient = FactoryBuild(baseUrl);
                string url = UrlCombine(baseUrl, apiPath, null);
                using HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Delete, url)
                {
                    Content = new StringContent(jsonParam, Encoding.UTF8, "application/json"),
                };

                if (!string.IsNullOrWhiteSpace(bearerToken))
                {
                    request.Headers.Add("Authorization", $"Bearer {bearerToken}");
                }
                else if (!string.IsNullOrWhiteSpace(m_BearerToken))
                {
                    request.Headers.Add("Authorization", $"Bearer {m_BearerToken}");
                }

                foreach (var item in m_HeaderDic)
                {
                    request.Headers.Add(item.Key, item.Value);
                }

                using HttpResponseMessage response = await httpClient.SendAsync(request, cancellationToken).ConfigureAwait(false);
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"代码：{(int)response.StatusCode}");
                }

                return await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            }
            catch (TaskCanceledException)
            {
                throw new Exception("网络连接失败");
            }
        }

        public void SetBearerToken(string token)
        {
            m_BearerToken = token;
        }

        private HttpClient FactoryBuild(string baseUrl)
        {
            IHttpClientFactory factory = m_ServiceProvider.GetService<IHttpClientFactory>();
            HttpClient httpClient = factory.CreateClient(HttpClientName);
            httpClient.BaseAddress = new Uri(baseUrl);
            return httpClient;
        }

        private string UrlCombine(string baseUrl, string apiUrl, Dictionary<string, string> param)
        {
            if (string.IsNullOrWhiteSpace(baseUrl))
            {
                baseUrl = string.Empty;
            }
            if (string.IsNullOrWhiteSpace(apiUrl))
            {
                apiUrl = string.Empty;
            }

            baseUrl = baseUrl.TrimEnd('/');
            apiUrl = apiUrl.TrimStart('/');
            string result = baseUrl + "/" + apiUrl;

            if (param is null || param.Count() == 0)
            {
                return result;
            }

            string connector = "?";
            foreach (var x in param)
            {
                result += $"{connector}{x.Key}={x.Value}";
                connector = "&";
            }

            return result;
        }

        public void SetHeader(string header, string value)
        {
            m_HeaderDic.Add(header, value);
        }
    }
}
