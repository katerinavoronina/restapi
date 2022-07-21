using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestAPI.Models
{
    public class ConfigData
    {
        [JsonProperty("baseUrl")]
        public string BaseUrl { get; set; }
    }
}
