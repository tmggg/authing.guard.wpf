using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authing.Guard.WPF.Models
{
    /// <summary>
    /// 企业登录源信息
    /// </summary>
    public class EnterpriseConnections
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("name_en")]
        public string Name_en { get; set; }

        [JsonProperty("Type")]
        public string Type { get; set; }

        [JsonProperty("Identifier")]
        public string identifier { get; set; }

        [JsonProperty("tooltip")]
        public Tooltip Tooltip { get; set; }

        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [JsonProperty("fields")]
        public Fields Fields { get; set; }
    }


    public class Fields
    {
        public string appId { get; set; }
    }

}
