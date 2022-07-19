using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authing.Guard.WPF.Models
{
    /// <summary>
    /// 社会化登录信息
    /// </summary>
    public class SocialConnection
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("provider")]
        public string Provider { get; set; }

        [JsonProperty("identifier")]
        public string Identifier { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("name_en")]
        public string Name_en { get; set; }

        [JsonProperty("authorizationUrl")]
        public string AuthorizationUrl { get; set; }

        [JsonProperty("tooltip")]
        public Tooltip Tooltip { get; set; }

        [JsonProperty("displayName")]
        public string DisplayName { get; set; }
    }

}
