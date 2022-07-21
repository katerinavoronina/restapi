using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestAPI.Models
{
    public class User
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("address")]
        public Address Address { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("website")]
        public string Website { get; set; }

        [JsonProperty("company")]
        public Company Company { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }    
            
            User user = obj as User;
            if (user as User == null)
            {
                return false;
            }             

            return 
                user.Id == this.Id && 
                user.Name == this.Name && 
                user.Username == this.Username && 
                user.Email == this.Email && 
                user.Phone == this.Phone && 
                user.Website == this.Website &&
                user.Address.Equals(this.Address) &&
                user.Company.Equals(this.Company);
        }
    }
}
