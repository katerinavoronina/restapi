using Newtonsoft.Json;
using RestAPI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace RestAPI.Utils
{
    public static class ConfigManager
    {
        private static string fileName = AppDomain.CurrentDomain.BaseDirectory + @"Data\config.json";
        private static string jsonString = File.ReadAllText(fileName, Encoding.Default);
        private static ConfigData configData = JsonConvert.DeserializeObject<ConfigData>(jsonString)!;

        public static ConfigData ConfigData
        {
            get
            {
                return configData;
            }
        }
    }
}
