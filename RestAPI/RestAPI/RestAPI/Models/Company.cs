using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestAPI.Models
{
    public class Company
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("catchPhrase")]
        public string CatchPhrase { get; set; }

        [JsonProperty("bs")]
        public string Bs { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
                
            Company company = obj as Company;
            if (company as Company == null)
            {
                return false;
            }                

            return 
                company.Name == this.Name && 
                company.CatchPhrase == this.CatchPhrase && 
                company.Bs == this.Bs;
        }
    }
}
