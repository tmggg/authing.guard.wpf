namespace Authing.Guard.WPF.Utils
{
    public interface IImageService
    {
        byte[] GetImageFromResponse(string url, string cookie = null);
    }
}