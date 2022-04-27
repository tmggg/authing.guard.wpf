using System;

namespace Authing.Guard.WPF.Utils
{
    /// <summary>
    /// 日志服务接口
    /// </summary>
    public interface ILogService
    {
        /// <summary>
        /// 打印普通日志信息
        /// </summary>
        /// <param name="info">日志内容</param>
        void InfoMessage(string info);

        /// <summary>
        /// 打印错误日志信息
        /// </summary>
        /// <param name="ex">异常</param>
        void ErrorMessage(Exception ex);
    }
}