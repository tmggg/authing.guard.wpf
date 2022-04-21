﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authing.Guard.WPF.Events
{
    /// <summary>
    /// 用户登录失败事件参数
    /// </summary>
    class LoginedErrorEventArgs : EventArgs
    {
        /// <summary>
        /// 错误信息，包含字段缺失／非法或服务器错误等信息
        /// </summary>
        public string Error { get; set; }
    }
}
