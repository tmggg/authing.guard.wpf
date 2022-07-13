using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authing.Guard.WPF.Models
{
    public class Agreement
    {
        [JsonProperty("userPoolId")]
        public string UserPoolId { get; set; }

        [JsonProperty("appId")]
        public string AppId { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// 界面语言
        /// </summary>
        [JsonProperty("lang")]
        public string Lang { get; set; }

        /// <summary>
        /// 必选
        /// </summary>
        [JsonProperty("required")]
        public bool Required { get; set; }

        [JsonProperty("order")]
        public int Order { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("availableAt")]
        public AvailableAt AvailableAt { get; set; }
    }

    public enum AvailableAt
    {
        /// <summary>
        /// 注册界面显示
        /// </summary>
        Register,
        /// <summary>
        /// 登录界面显示
        /// </summary>
        Login,
        /// <summary>
        /// 注册及登录界面显示
        /// </summary>
        RegisterAndLogin
    }
}
