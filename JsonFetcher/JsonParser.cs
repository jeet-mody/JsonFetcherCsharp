using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JsonFetcher
{
    public class JsonParser
    {
        public string FormatJson(string json)
        {
            var parsedJson = JToken.Parse(json);
            return FormatToken(parsedJson);
        }

        private string FormatToken(JToken token)
        {
            if (token is JArray)
            {
                return FormatArray((JArray)token);
            }
            else if (token is JObject)
            {
                return FormatObject((JObject)token);
            }
            else
            {
                return token.ToString(Formatting.Indented);
            }
        }

        private string FormatArray(JArray array)
        {
            return array.ToString(Formatting.Indented);
        }

        private string FormatObject(JObject obj)
        {
            return obj.ToString(Formatting.Indented);
        }
    }
}
