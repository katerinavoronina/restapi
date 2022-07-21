using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestAPI.Models
{
    public class Geo
    {
        [JsonProperty("lat")]
        public string Lat { get; set; }

        [JsonProperty("lng")]
        public string Lng { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
                 
            Geo geo = obj as Geo;
            if (geo as Geo == null)
            {
                return false;
            }
                
            return geo.Lat == this.Lat && geo.Lng == this.Lng;
        }
    }
}
