using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace Common
{
    public class CommonActions
    {
        public static T DeserilizeJsonCamelCase<T>(string jsonString)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            T t;
            try
            {
                t = JsonConvert.DeserializeObject<T>(jsonString, settings);
            }
            catch (JsonSerializationException)
            {
                t = default;
            }

            return t;
        }

        public static T Deserilize<T>(string jsonString)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            T t;
            try
            {
                t = JsonConvert.DeserializeObject<T>(jsonString, settings);

            }
            catch (JsonSerializationException)
            {
                t = default;
            }

            return t;
        }

        public static string SerilizeToJsonCamelCase(object body)
        {
            var serializerSettings = new JsonSerializerSettings();
            DefaultContractResolver contractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };
            serializerSettings.ContractResolver = contractResolver;
            return JsonConvert.SerializeObject(body, serializerSettings);
        }

        public static string SerilizeToJson(object body)
        {
            return JsonConvert.SerializeObject(body);
        }

        public static List<T> DeserializeToList<T>(string content)
        {
            return JsonConvert.DeserializeObject<List<T>>(content);
        }

        public static Dictionary<string, string> TableToDictionary(Table table)
        {
            var dictionary = new Dictionary<string, string>();
            foreach (var row in table.Rows)
            {
                dictionary.Add(row[0], row[1]);
            }
            return dictionary;
        }
    }
}
