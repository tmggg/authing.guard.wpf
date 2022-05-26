using Authing.Guard.WPF.Enums;
using System;

namespace Authing.Guard.WPF.Models
{
    public class LocalesConfig
    {
        /// <summary>
        /// 默认使用的语言
        /// </summary>
        public Lang DefaultLang { get; set; }

        /// <summary>
        /// 在 Guard 中是否显示语言切换控件
        /// </summary>
        public bool IsShowChange { get; set; }

        /// <summary>
        /// 在使用 Guard 控件切换语言时的回调
        /// </summary>
        public Action<Lang> OnChange { get; set; }
    }
}