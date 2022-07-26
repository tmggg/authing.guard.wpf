namespace Authing.Guard.WPF.Utils
{
    /// <summary>
    /// Json 服务的接口
    /// </summary>
    public interface IJsonService
    {
        /// <summary>
        /// 将对象序列化为字符串
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        string Serialize(object obj);

        /// <summary>
        /// 反序列化字符串
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonText">待反序列化的字符串参数</param>
        /// <returns></returns>
        T Deserialize<T>(string jsonText);

        /// <summary>
        /// 反序列化字符串忽略大小写
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonText">待反序列化的字符串参数</param>
        /// <returns></returns>
        T DeserializeCamelCase<T>(string jsonText);
    }
}