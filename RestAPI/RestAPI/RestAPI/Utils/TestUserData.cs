using Newtonsoft.Json;
using RestAPI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace RestAPI.Utils
{
    public static class TestUserData
    {
        private static string fileName = AppDomain.CurrentDomain.BaseDirectory + @"Data\testUser.json";
        private static string jsonString = File.ReadAllText(fileName, Encoding.Default);
        private static User user = JsonConvert.DeserializeObject<User>(jsonString);

        public static User User
        {
            get
            {
                return user;
            }
        }
    }
}
