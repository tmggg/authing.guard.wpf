using System.Runtime.InteropServices;

namespace Authing.Guard.WPF.Utils.Impl
{
    public class WindowsAPI : IWindowsAPI
    {
        public void ShellExecute(string operation, string file)
        {
            ShellExecute(0, operation, file, "", "", 1);
        }

        /// <summary>
        /// 默认打开器
        /// </summary>
        /// <param name="hwnd">传0即可</param>
        /// <param name="operation">操作，传open</param>
        /// <param name="file">传网址</param>
        /// <param name="param">无</param>
        /// <param name="directory">无</param>
        /// <param name="nShowCmd">SW_SHOWNORMAL SW_NORMAL 1</param>
        [DllImport("Shell32.dll")]
        public static extern void ShellExecute(int hwnd, string operation, string file, string param, string directory, int nShowCmd);
    }
}