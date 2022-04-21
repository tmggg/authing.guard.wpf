using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authing.Guard.WPF.Enums
{
    /// <summary>
    /// Guard 可展示的界面
    /// </summary>
    public enum GuardScenes
    {
        /// <summary>
        /// 登录界面
        /// </summary>
        [Description("login")]
        Login,
        /// <summary>
        /// 注册界面
        /// </summary>
        [Description("register")]
        Register
    }
}
