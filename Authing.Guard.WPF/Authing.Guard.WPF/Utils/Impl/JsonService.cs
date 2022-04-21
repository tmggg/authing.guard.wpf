using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
