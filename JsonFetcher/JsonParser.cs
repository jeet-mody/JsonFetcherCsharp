using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JsonFetcher
{
    public class JsonParser
    {
        public string FormatJson(string json)
        {
            var parsedJson = JToken.Parse(json);
            return parsedJson.ToString(Formatting.Indented);
        }
    }
}
