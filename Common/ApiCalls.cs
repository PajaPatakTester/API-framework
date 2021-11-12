using RestSharp;
using System.Collections.Generic;
using System.Linq;

namespace Common
{
    public class ApiCalls
    {
        private const string Url = "https://api.openweathermap.org/data/2.5/weather";
        private static Dictionary<string, string> ApiKey = new Dictionary<string, string>() { ["appid"] = "53d1968dfb034b71be869593d68ef11c" };

        public static RestResponse Get(string paramKey = null, string paramValue = null)
        {
            Utility.Request.Method = Method.GET;
            Utility.Request.Resource = Url;
            Utility.Request.Body = null;
            Utility.Request.AddOrUpdateParameter(ApiKey.Keys.ElementAt(0), ApiKey.Values.ElementAt(0));
            if (paramKey != null)
                Utility.Request.AddOrUpdateParameter(paramKey, paramValue);

            RestResponse response = Utility.Client.Execute(Utility.Request) as RestResponse;

            //cleanup for other calls
            if (paramKey != null)
                Utility.Request.Parameters.Remove(Utility.Request.Parameters.Find(x => x.Name.Contains(paramKey)));

            return response;
        }

        public static RestResponse Post(string resourcePath, object body)
        {
            Utility.Request.Method = Method.POST;
            Utility.Request.Resource = resourcePath;
            Utility.Request.Body = null;
            Utility.Request.AddOrUpdateParameter("application/json", CommonActions.SerilizeToJson(body), ParameterType.RequestBody);
            return Utility.Client.Execute(Utility.Request) as RestResponse;
        }

        public static RestResponse Post(string resourcePath)
        {
            Utility.Request.Method = Method.POST;
            Utility.Request.Resource = resourcePath;
            Utility.Request.Body = null;
            Utility.Request.AddOrUpdateParameter("application/json", ParameterType.RequestBody);
            RestResponse response = Utility.Client.Execute(Utility.Request) as RestResponse;

            //cleanup for other calls
            Utility.Request.Parameters.RemoveAll(x => x.Type == ParameterType.RequestBody);

            return response;
        }

        public static RestResponse Put(string resourcePath, object body)
        {
            Utility.Request.Method = Method.PUT;
            Utility.Request.Resource = resourcePath;
            Utility.Request.Body = null;

            Utility.Request.AddParameter("application/json", CommonActions.SerilizeToJson(body), ParameterType.RequestBody);
            RestResponse response = Utility.Client.Execute(Utility.Request) as RestResponse;

            //cleanup for other calls
            Utility.Request.Parameters.RemoveAll(x => x.Type == ParameterType.RequestBody);
            return response;
        }

        public static RestResponse Patch(string resourcePath)
        {
            Utility.Request.Method = Method.GET;
            Utility.Request.Resource = resourcePath;
            Utility.Request.Body = null;
            return Utility.Client.Execute(Utility.Request) as RestResponse;
        }

        public static RestResponse Delete(string resourcePath, string paramKey = null, string paramValue = null)
        {
            Utility.Request.Method = Method.DELETE;
            Utility.Request.Resource = resourcePath;
            if (paramKey != null) Utility.Request.AddOrUpdateParameter(paramKey, paramValue);

            return Utility.Client.Execute(Utility.Request) as RestResponse;
        }
    }
}
