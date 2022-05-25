using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authing.Guard.WPF.Utils
{
    public interface IImageService
    {
        byte[] GetImageFromResponse(string url, string cookie = null);
    }
}
