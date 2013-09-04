using System;
using RestSharp;
using Newtonsoft.Json.Linq;

namespace GW2API.Common
{
    class API
    {
        private static readonly string apiVersion = "v0.9";
        private static readonly string format = "json";
        private static readonly string apiURL = @"http://http://www.gw2spidy.com/api/" + apiVersion + "/" + format + "/";

        private static readonly string itemDataParamter = "{dataID}";
        private static readonly string itemDataRequest = apiURL + "/item/" + itemDataParamter;


        private static RestClient client = new RestClient(apiURL);

        public JObject itemData(int dataID)
        {
            RestRequest request = new RestRequest(itemDataRequest, Method.GET);
            request.AddUrlSegment(itemDataParamter, dataID.ToString());

            return JObject.Parse(client.Execute(request).Content);
        }

        private RestRequest makeRequest(string requestString)
        {
            RestRequest request = new RestRequest(@"{version}/{format}/" + requestString);
            request.AddUrlSegment("version", apiVersion);
            request.AddUrlSegment("format", format);

            return request;
        }
    }
}
