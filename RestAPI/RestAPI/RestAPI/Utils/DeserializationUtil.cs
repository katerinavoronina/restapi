using Newtonsoft.Json;
using RestAPI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestAPI.Utils
{
    public static class DeserializationUtil
    {
        public static List<T> GetResponseContentList<T>(string jsonResponse)
        {
            return JsonConvert.DeserializeObject<List<T>>(jsonResponse);
        }

        public static T GetResponseContent<T>(string jsonResponse)
        {
            return JsonConvert.DeserializeObject<T>(jsonResponse);
        }
    }
}
