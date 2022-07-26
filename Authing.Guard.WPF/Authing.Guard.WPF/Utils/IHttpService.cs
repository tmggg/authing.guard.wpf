using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Authing.Guard.WPF.Utils
{

    internal interface IHttpService
    {
        /// <summary>
        /// Get请求
        /// </summary>
        /// <param name="baseUrl"></param>
        /// <param name="apiPath"></param>
        /// <param name="param"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="bearerToken">临时token，只这一次生效，如果为null，则使用SetBearerToken设置的token</param>
        /// <returns></returns>
        Task<string> GetAsync(string baseUrl, string apiPath, Dictionary<string, string> param, CancellationToken cancellationToken, string bearerToken = null);

        /// <summary>
        /// Post请求
        /// </summary>
        /// <param name="baseUrl"></param>
        /// <param name="apiPath"></param>
        /// <param name="param"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="bearerToken">临时token，只这一次生效，如果为null，则使用SetBearerToken设置的token</param>
        /// <returns></returns>
        Task<string> PostAsync(string baseUrl, string apiPath, Dictionary<string, object> param, CancellationToken cancellationToken, string bearerToken = null);

        /// <summary>
        /// Post请求
        /// </summary>
        /// <param name="baseUrl"></param>
        /// <param name="apiPath"></param>
        /// <param name="jsonParam"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="bearerToken">临时token，只这一次生效，如果为null，则使用SetBearerToken设置的token</param>
        /// <returns></returns>
        Task<string> PostAsync(string baseUrl, string apiPath, string jsonParam, CancellationToken cancellationToken, string bearerToken = null);

        /// <summary>
        /// Put请求
        /// </summary>
        /// <param name="baseUrl"></param>
        /// <param name="apiPath"></param>
        /// <param name="jsonParam"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="bearerToken"></param>
        /// <returns></returns>
        Task<string> PutAsync(string baseUrl, string apiPath, string jsonParam, CancellationToken cancellationToken, string bearerToken = null);

        /// <summary>
        /// Delete请求
        /// </summary>
        /// <param name="baseUrl"></param>
        /// <param name="apiPath"></param>
        /// <param name="jsonParam"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="bearerToken"></param>
        /// <returns></returns>
        Task<string> DeleteAsync(string baseUrl, string apiPath, string jsonParam, CancellationToken cancellationToken, string bearerToken = null);

        /// <summary>
        /// 设置token，以后每次请求都带这个token
        /// </summary>
        void SetBearerToken(string token);

        /// <summary>
        /// 设置头
        /// </summary>
        /// <param name="header"></param>
        /// <param name="value"></param>
        void SetHeader(string header, string value);
    }


}
