using RestSharp;

namespace RestAPI.Utils
{
    public static class ApiUtil
    {
        public static RestResponse GetRequest(string baseUrl, string resource)
        {
            var client = new RestClient(baseUrl);
            var request = new RestRequest(resource, Method.Get);
            return client.Execute(request);
        }

        public static RestResponse PostRequest(string baseUrl, string resource, object value)
        {
            var client = new RestClient(baseUrl);
            var request = new RestRequest(resource, Method.Post);
            request.AddObject(value);
            return client.Execute(request);
        }
    }
}
