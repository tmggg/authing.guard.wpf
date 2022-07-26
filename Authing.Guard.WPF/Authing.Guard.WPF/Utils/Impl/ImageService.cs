using System;
using System.IO;
using System.Net;

namespace Authing.Guard.WPF.Utils.Impl
{
    internal class ImageService : IImageService
    {
        public byte[] GetImageFromResponse(string url, string cookie = null)
        {
            redo:
            try
            {
                WebRequest request = WebRequest.Create(url);
                if (!string.IsNullOrWhiteSpace(cookie))
                {
                    request.Headers[HttpRequestHeader.Cookie] = cookie;
                }

                WebResponse response = request.GetResponse();

                using (Stream stream = response.GetResponseStream())
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        Byte[] buffer = new byte[1024 * 10];
                        int current = 0;
                        do
                        {
                            ms.Write(buffer, 0, current);
                        }
                        while ((current = stream.Read(buffer, 0, buffer.Length)) != 0);

                        return ms.ToArray();
                    }
                }
            }
            catch (System.Net.WebException ex)
            {
                if (ex.Message == "基础连接已经关闭: 发送时发生错误。")
                {
                    goto redo;
                }
                else
                {
                    throw;
                }
            }
        }
    }
}