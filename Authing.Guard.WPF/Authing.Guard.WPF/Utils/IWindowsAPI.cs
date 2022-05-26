namespace Authing.Guard.WPF.Utils
{
    public interface IWindowsAPI
    {
        /// <summary>
        /// 默认打开文件
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="file"></param>
        void ShellExecute(string operation, string file);
    }
}