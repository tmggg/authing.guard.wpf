using Newtonsoft.Json;

namespace Authing.Guard.WPF.Utils.Impl
{
    public class JsonService : IJsonService
    {
        public T Deserialize<T>(string jsonText)
        {
            return JsonConvert.DeserializeObject<T>(jsonText);
        }

        public string Serialize(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public T DeserializeCamelCase<T>(string jsonText)
        {
            var setting = new JsonSerializerSettings
            {
                ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver(),
                NullValueHandling = NullValueHandling.Ignore
            };

            return JsonConvert.DeserializeObject<T>(jsonText, setting);
        }
    }
}