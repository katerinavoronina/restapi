using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestAPI.Models
{
    public class Address
    {
        [JsonProperty("street")]
        public string Street { get; set; }

        [JsonProperty("suite")]
        public string Suite { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("zipcode")]
        public string Zipcode { get; set; }

        [JsonProperty("geo")]
        public Geo Geo { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
                
            Address address = obj as Address;
            if (address as Address == null)
            {
                return false;
            }               

            return 
                address.Street == this.Street && 
                address.Suite == this.Suite && 
                address.City == this.City &&
                address.Zipcode == this.Zipcode &&
                address.Geo.Equals(this.Geo);
        }
    }
}
