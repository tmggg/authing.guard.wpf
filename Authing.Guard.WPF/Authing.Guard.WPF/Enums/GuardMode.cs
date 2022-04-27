using System.ComponentModel;

namespace Authing.Guard.WPF.Enums
{
    public enum GuardMode
    {
        /// <summary>
        /// 弹窗模式
        /// </summary>
        [Description("modal")]
        Modal,

        /// <summary>
        /// 正常模式
        /// </summary>
        [Description("normal")]
        Normal
    }
}