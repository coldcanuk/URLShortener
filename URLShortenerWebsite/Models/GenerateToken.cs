using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace URLShortenerWebsite.Models
{
    public static class GenerateToken
    {
        public static string Generate()
        {
            string safeURLChars = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz0123456789";
            Random random = new Random();
            int randomLength = random.Next(4, 8);
            char[] randomChars = new char[randomLength];

            for(int i = 0; i < randomChars.Length; i++)
            {
                randomChars[i] = safeURLChars[random.Next(safeURLChars.Length)];
            }

            string token = new string(randomChars);
            return token;
        }
    }
}
