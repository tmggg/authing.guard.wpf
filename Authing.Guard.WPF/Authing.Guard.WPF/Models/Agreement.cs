using Authing.Guard.WPF.Infrastructures;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authing.Guard.WPF.Models
{
    public class Agreement: NotifyPropertyChanged
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

        private bool m_IsChecked;
        public bool IsChecked
        {
            get => m_IsChecked;
            set => SetProperty(ref m_IsChecked, value);
        }

        private bool m_Warn;
        /// <summary>
        /// 是否警告
        /// </summary>
        public bool Warn
        {
            get => m_Warn;
            set => SetProperty(ref m_Warn, value);
        }

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
