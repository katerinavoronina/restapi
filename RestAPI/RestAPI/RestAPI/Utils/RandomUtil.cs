using System;
using System.Collections.Generic;
using System.Text;

namespace RestAPI.Utils
{
    public static class RandomUtil
    {
        private static string alphabet = "QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm";

        public static string GetRandomString()
        {
            Random rnd = new Random();
            int length = rnd.Next(7, 25);
            StringBuilder sb = new StringBuilder(length - 1);
            int position = 0;
            for (int i = 0; i < length; i++)
            {
                position = rnd.Next(0, alphabet.Length - 1);
                sb.Append(alphabet[position]);
            }

            return sb.ToString();
        }
    }
}
